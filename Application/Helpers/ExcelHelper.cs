using Application.DTOs;
using Application.Interface;
using Application.Services;
using Domain.Interface;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class ExcelHelper<T> where T : class, new()
    {
        private IExcelDataReader _reader;
        private readonly ICompanyRepository _companyRepository;
            
        public ExcelHelper(IFormFile file, ICompanyRepository companyRepository)
        {
            var stream = file.OpenReadStream();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (file.FileName.EndsWith(".csv"))
            {
                _reader = ExcelReaderFactory.CreateCsvReader(stream);
            }

            _companyRepository = companyRepository;

        }

        public List<T> GetValues()
        {
            var list = new List<T>();
            var table = ConvertToDataTable();

            var properties = typeof(T).GetProperties().ToList();
            foreach ( var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                list.Add(item);
            }

            return list;
        }

        private DataTable ConvertToDataTable()
        {
            var configuration = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = x => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };

            var dataSet = _reader.AsDataSet(configuration);
            return dataSet.Tables[0];
        }

        private T CreateItemFromRow<T>(DataRow row,IList<PropertyInfo> properties) where T : class, new() 
        { 
            var item = new T();

            foreach(var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    var collumnValue = row[property.Name];

                    if(row[property.Name] == DBNull.Value)
                    {
                        if(property.PropertyType == typeof(int))
                        {
                            property.SetValue(item, 0);
                        }
                        else
                        {
                            property.SetValue(item, null);
                        }                        
                    }
                   
                    if(property.PropertyType == typeof(int)) 
                    {
                       var validation = VerifyIfCompanyExist(int.Parse(collumnValue.ToString()));
                       if (property.Name == "CompanyId" && (!validation))
                       {
                            property.SetValue(item, 0);
                       }
                       else
                       {
                            property.SetValue(item, Convert.ToInt32(row[property.Name]));                            
                       }
                        
                    }
                    else
                    {
                        property.SetValue(item, row[property.Name]);
                    }               
                }                
            }
            return item;
        }

        public bool VerifyIfCompanyExist(int id)
        {
            var validation =  _companyRepository.GetById(id);
            if (validation.Result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool Validation(ContactDTO contactDTO)
        {
            if (string.IsNullOrWhiteSpace(contactDTO.Name) || string.IsNullOrWhiteSpace(contactDTO.Email) || string.IsNullOrWhiteSpace(contactDTO.PhoneNumber)) return false;
            if (contactDTO.ContactBookId == 0) return false;

            return true;
        }

    }
}
