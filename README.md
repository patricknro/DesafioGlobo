# Desafio Globo

Como era um projeto simples não foi utilizado os conceitos do DDD para estruturação do Projeto, devido a isso foi montado um projeto com três camadas (UI, Business e Data(dto)). <br /> <br />
***Observação***: Na Solução contém uma pasta _collection_postman_ que pode ser importada pelo Postman e executar as API construídas na aplicação.

### Framework
```
.NET Core 3.1
```

### Nuget Package

```
Swashbuckle.AspNetCore 5.6.3
```

### Comandos para Execução da Aplicação

Entre no diretório de onde foi realizado o clone da aplicação e execute os comandos abaixo.

1. Restaura os pacotes utilizados no projeto.
	```
	> dotnet restore
	```
2. Navegue até a pasta do projeto
	```
	> cd .\Desafio.API\
	```
3. Por fim, execute o comando abaixo para rodar projeto
	```
	> dotnet run
	```
	
**Observação**: No console ou powershell mostra um número de porta diferente do que esta configurado no projeto. <br />
Caso isso venha acontencer, então é preciso copiar a url colocar no endereço do seu browser e complementar com _/swagger_ para testar as APIs desenvolvidas. 

### URL Projeto
```
http://localhost:58715/swagger
```

