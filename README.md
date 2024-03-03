#  Resultado Teste back-end enContact

- [X] Criar, editar, excluir e listar agendas. -

- Fiz o create de agendas aqui para cumprir o requisito, mas na lógica do projeto eu implementei o create da agenda junto com o create das empresas ou seja quando CRIAR uma empresa automaticamente ja é criado a agenda.



<img src="https://github.com/Wellington-Climaco/DesafioDotnetBackendJunior2024/assets/142629826/7f454092-f116-407d-9328-86ec1d4578ac" width=40% height=40%>
    
- [X] Criar, editar, excluir e listar empresas.

<img src="https://github.com/Wellington-Climaco/DesafioDotnetBackendJunior2024/assets/142629826/0c93c235-84a2-473f-8edb-e4fcb6ae819e" width=40% height=40%>

============================================================

 - [X] Importar contatos a partir de um arquivo .csv - Todos Requisitos cumpridos.
 
 - As linhas em amarelo representam os seguintes erros: sem nome, sem email, já existente no sistema, sem numero de telefone e empresa inexistente no sistema. O contato com uma empresa inexistente é registrado sem vinculo com empresas, e o resto são excluidos da importação.

 - Irei deixar um CSV de exemplo no repositorio para possivel teste no Endpoint.

<img src="https://github.com/Wellington-Climaco/DesafioDotnetBackendJunior2024/assets/142629826/a2c85ffc-be0c-4888-81be-11b155f35115" width=40% height=40%>

============================================================

- [X] Pesquisar contatos
- [X] Deve pesquisar em qualquer campo do contato (incluído o nome da empresa).
- [X] O parâmetro de entrada deve ser apenas uma string (Semelhante a pesquisa do google onde tem apenas um campo texto)

<img src="https://github.com/Wellington-Climaco/DesafioDotnetBackendJunior2024/assets/142629826/58dfd2b8-404b-4856-bcc5-9c17417a35be" width=40% height=40%>       
       
- [X] A pesquisa deve ser paginada (Fique a vontade para utilizar qualquer estratégia).

- No JSON retorno o current page, take e total para facilitar uma posterior implementação do FrontEnd

<img src="https://github.com/Wellington-Climaco/DesafioDotnetBackendJunior2024/assets/142629826/aa13e1e7-4de4-4bfb-9d22-19e4d5e388e7" width=40% height=40%> 

============================================================

- [X] Pesquisa de contatos da empresa (A partir de uma pesquisa pelo nome ou parte do nome, ou seja, a entrada é um texto)


<img src="https://github.com/Wellington-Climaco/DesafioDotnetBackendJunior2024/assets/142629826/0b1d583a-b96f-4546-8bd9-0a0cfd5637e6" width=60% height=60%> 

- [X] Deve retornar os contatos agrupados pela agenda.

<img src="https://github.com/Wellington-Climaco/DesafioDotnetBackendJunior2024/assets/142629826/2ca1a8a2-0988-41fd-a90d-400500ac7127" width=40% height=40%> 

============================================================

###  Considerações

Como poderiamos refatorar da forma que quiséssemos optei por utilizar: Entity Framework e Clean Architecture.

Agradeço pelo desafio, com ele precisei aprender sobre importação de arquivos em APIs, exercitei meus conhecimentos em Clean Architecture e tive o desafio de trabalhar com o .NET 5, versão que não estou acostumado.

Espero ver vocês novamente nas proximas etapas do processo seletivo.

Abraços.








  





      





      
