# HealthMed.Backend.Fiap


|Alunos| E-mail|
|------|-------|
|Elielson do Nascimento Rodrigues|elielsonrj@hotmail.com|
|RAFAEL FAUSTINO MAGALHAES PONTIN|rfmpontin@gmail.com|
|Alexssander Ferreira do Nascimento|alexssanderferreira@hotmail.com|
|Antonio Andderson de Freitas Soares|andderson.freitas@gmail.com|

___
## Tecnologias Utilizadas
- Linguagem de Programação: C#
- Framework: .NET
- Banco de Dados: SQL Server
- Autenticação: JWT

___

- Criterio de aceite do projeto : https://github.com/RafaelPontin/HealthMed.Backend.Fiap/wiki

## Rodar Projeto 
- Clone o Repositorio
- Instale o .NET 7 e o Sql Server
- Rode o Migration com o Comando: 
  ```bash Update-Database```
  
  ![image](https://github.com/user-attachments/assets/b45ba290-16eb-4648-9ec0-5905b625fab7)

- Será criado o banco no SQL Server:
  
  ![image](https://github.com/user-attachments/assets/f5d2c15c-d8dc-4e8a-9c6d-6ddbc3bb6a7a)

- Selecione o Projeto como inicializavel **HealthMed.Backend.API** :

![image](https://github.com/user-attachments/assets/2431a808-1763-446f-845a-f9f5f717d221)

- Execute o projeto:

![image](https://github.com/user-attachments/assets/f5c00c49-5da9-4778-897a-6db8d38cc779)

- Se todos os passos anteriores foram executados corretamente, o Swagger será aberto automaticamente.
  
  ![image](https://github.com/user-attachments/assets/062bef07-a808-4cb0-b0d0-e4ce8a127830)

  ___
  # End Points

 ## Usuário
- Cadastrar Médico
  - Método: POST
  - URL: /api/Usuario/cadastrar-medico
  - Descrição: End point responsável pela criação do médico.
  - Exemplo de Request Body:
    ```json
    {
      "nome": "string", 
      "cpf": "string",  
      "email": "string", 
      "confirmacaoSenha": "string", 
      "senha": "string", 
      "crm": "string"
    }
    ```
  - Exemplo de Response Body:
  ```json
  {
    "data": {
      "id": "Guid",
      "nome": "string",
      "cpf": "string",
      "email": "string",
      "crm": "string"
    },
    "title": "string",
    "status": "int",
    "erros": [
      "string"
    ]
  }
  ```
    
- Cadastrar Paciente
  - Método: POST
  - URL: /api/Usuario/cadastrar-paciente
  - Descrição: End point responsável pela criação do paciente.
  - Exemplo de Request Body:
    ```json
    {
      "nome": "string", 
      "cpf": "string", 
      "email": "string", 
      "confirmacaoSenha": "string", 
      "senha": "string"
    }
    ```
    - Exemplo de Response Body:
      ```json
      {
        "data": {
          "id": "Guid",
          "nome": "string",
          "cpf": "string",
          "email": "string",
          "crm": "string"
        },
        "title": "string",
        "status": "int",
        "erros": [
          "string"
        ]
      }
      ```
    

- Login
  - Método: POST
  - URL: /api/Usuario/Login
  - Descrição: End point responsável pelo login do usuário.
  - Exemplo de Request Body:
    ```json
    {
      "login": "string",  
      "senha": "string"
    }
    ```
    - Exemplo de Response Body:
      ```json
      {
        "data": {
          "id": "Guid",
          "nome": "string",
          "email": "string",
          "accessToken": "string"
        },
        "title": "string",
        "status": "int",
        "erros": [
          "string"
        ]
      }
      ```
    
- Buscar Agenda do Médico
  - Método: GET
  - URL: /api/Usuario/buscar-agenda-medico
  - Autorização: Bearer <token>
  - Descrição: End point responsável por retornar os médicos disponíveis para o paciente autenticado.
    - Exemplo de Response Body:
      ```json
          {
            "data": [
              {
                "id": "Guid",
                "nome": "string",
                "cpf": "string",
                "email": "string",
                "crm": "string"
              }
            ],
            "title": "string",
            "status": "int",
            "erros": [
              "string"
            ]
          }
      ```
      - Exemplo de Response Body:
      ```json
      {
        "data": [
          {
            "id": "Guid",
            "nome": "string",
            "cpf": "string",
            "email": "string",
            "crm": "string"
          }
        ],
        "title": "string",
        "status": "int",
        "erros": [
          "string"
        ]
      }
      ```
    
- Buscar Agenda do Médico por ID
  - Método: GET
  - URL: /api/Usuario/buscar-agenda-medico/{idMedico}
  - Autorização:  Bearer <token>
  - Descrição: End point responsável por retornar os horários disponíveis pelo ID do médico.
  - Exemplo de Response Body:
      ```json
      {
        "data": [
          {
            "id": "Guid",
            "horarioInicio": "DateTime",
            "horarioFinal": "DateTime",
            "nomeMedico": "string",
            "medicoId": "Guid"
          }
        ],
        "title": "string",
        "status": "int",
        "erros": [
          "string"
        ]
      }
      ```

## Horario

- Cadastra Horario
  - Método: POST
  - URL: /api/Horario/cadastrar-horarios
  - Autorização:  Bearer <token>
  - Descrição: End point responsável por cadastrar o horario disponivel do medico.
  - Exemplo de Request Body:
    ```json
    {
      "horarioInicio": "DateTime",
      "horarioFinal": "DateTime"
    }
    ```
    - Exemplo de Response Body:
     ```json
     {
        "data": {
          "id": "Guid",
          "horarioInicio": "DateTime",
          "horarioFinal": "DateTime"
        },
        "title": "string",
        "status": "int",
        "erros": [
          "string"
        ]
      }
      ```
      

- Alterar Horario
  - Método: PUT
  - URL: /api/Horario/alterar-horarios
  - Autorização:  Bearer <token>
  - Descrição: End point responsável por alterar o horario já cadastrado do medico.
  - Exemplo de Request Body:
  ```json
    {
      "horarioInicio": "DateTime",
      "horarioFinal": "DateTime",
      "idHorario": "Guid"
    }
  ```
 - Exemplo de Response Body:
     ```json
       {
          "data": {
            "id": "Guid",
            "horarioInicio": "DateTime",
            "horarioFinal": "DateTime"
          },
          "title": "string",
          "status": "int",
          "erros": [
              "string"
          ]
     }
     ``` 
  

- Horário Indisponível
    - Método: PUT
    - URL: /api/Horario/horario-indisponivel/{idHorario}
    - Autorização:  Bearer <token>
    - Descrição: End point responsável por cancelar o horario já cadastrado do medico.
    - Exemplo de Response Body:
     ```json
     {
        "data": "boolean",
        "title": "string",
        "status": "int",
        "erros": [
          "string"
        ]
      }
     ```
 
## Agendamento

- Obter Agendamento Por Paciente
  - Método: GET
  - URL: /api/Agendamento/ObterAgendamentoPorPaciente
  - Autorização:  Bearer <token>
  - Descrição: End point responsável por retornar todas as consulta do paciente.
  - Exemplo de Response Body:
     ```json
         {
        "data": [
          {
            "id": "Guid",
            "horarioCriacao": "DateTime",
            "paciente": {
              "id": "Guid",
              "nome": "string",
              "cpf": "string",
              "email": "string",
              "crm": "string"
            },
            "horario": {
              "id": "Guid",
              "horarioInicio": "DateTime",
              "horarioFinal": "DateTime"
            }
          }
        ],
        "title": "string",
        "status": "int",
        "erros": [
          "string"
        ]
      }
      ```
- Novo Agendamento
  - Método: POST
  - URL: /api/Agendamento/NovoAgendamento
  - Autorização:  Bearer <token>
  - Descrição: End point responsável por agendar um horario com o medico, caso obtenha sucesso no cadastro é disparado um email para o medico.
  - Exemplo de Request Body:
  ```json
    {
      "horarioId": "Guid"
    }
  ```
  - Exemplo de Response Body:
     ```json
     {
      "data": "boolean",
      "title": "string",
      "status": "int",
      "erros": [
        "string"
      ]
    }
     ```
  - Caso tenho sucesso no agendamento, receberar esse email:
    
  ![image](https://github.com/user-attachments/assets/9b914a1e-c56f-4372-a054-88db6e172768)

- Cancelar Agendamento
    - Método: DELETE
    - URL: /api/Agendamento/CancelarAgendamento/{idAgendamento}
    - Autorização:  Bearer <token>
    - Descrição: End point responsável por cancelar o agendamento de um horario com o medico, caso obtenha sucesso no cancelamento e disparado um email para o medico
    - Exemplo de Response Body:
     ```json
        {
          "data": "boolean",
          "title": "string",
          "status": "int",
          "erros": [
            "string"
          ]
        }
   ```
