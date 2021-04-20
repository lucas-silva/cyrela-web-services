## Gestão de Vistoria e Garantia

Repositório com código, manual de integração e execução dos serviços web de vistoria e garantia Cyrela

### Para documentação dos serviços web Cyrela

Acesse a <a href="https://github.com/lucas-silva/cyrela-web-services/raw/main/docs/Documenta%C3%A7%C3%A3o%20API%20-%20Cyrela.pdf">documentação de integração</a>

### Executando banco de dados mysql local com docker

```
docker run --name cyrela-mysql -e MYSQL_ROOT_PASSWORD=password -d -p 3306:3306 mysql:8.0.24
```

### Para executar a aplicação em ambiente local

Execute o comando abaixo na raiz do projeto:

```
dotnet run --project src/App
```

### Para acessar a documentação auto-gerada:

Abra o navegador na URL: https://localhost:5001 ou http://localhost:500
