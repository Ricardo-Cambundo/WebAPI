
# .NET Web API with C# & PostgreSQL 

The focal point of this API revolves around managing product data efficiently.

This repository serves as a robust foundation for web applications or system integrations requiring seamless product management capabilities. Feel free to delve into the codebase, contribute enhancements, or seamlessly integrate it into your projects.

Let me know if there's anything else you'd like to include or modify!

## API Reference

Its run locally, but these are the endpoints.

#### Get all products

```http
  GET /api/Produto/Produtos
```

#### Add product

```http
  POST /api/Produto/AdProduto
```
Example value: 
`{
  "id": 0,
  "nome": "string",
  "categoria": "string",
  "preco": 0,
  "dataExpiracao": "2024-03-03T19:33:03.198Z",
  "localizacao": "string",
  "descricao": "string",
  "contato": "string",
  "disponivelOnline": true,
  "avaliacao": 0
}`

#### Update product

```http
  POST /api/Produto/AtualizarProduto
```

#### Get products by price

```http
  GET /api/Produto/CarregarProdutosPorPreco/{preco}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `preco`      | `number($double)` | **Required**. price of products to fetch |


#### Get products by expiration date

```http
  GET /api/Produto/CarregarProdutosPorDataExpiracao/{dataExpiracao}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `dataExpiracao`      | `string($date-time)` | **Required**. expiration date of products to fetch |

#### Get products by category

```http
  GET /api/Produto/CarregarProdutosPorCategoria/{categoria}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `categoria`      | `string` | **Required**. category of products to fetch |


## Authors

- [@RicardoCambundo](https://www.github.com/Ricardo-Cambundo/)


## Features

- Product Model: Central to the API is a versatile product model, facilitating seamless management and manipulation of product data.

- RESTful Endpoints: The API exposes a set of RESTful endpoints for all CRUD operations on products, ensuring a standardized and intuitive interface for interacting with the data.

- Swagger Documentation: Implemented with Swagger, the API offers interactive and comprehensive documentation. This feature streamlines API exploration, testing, and integration efforts, enhancing developer productivity and comprehension.


## Support

For support, email ricardocmbd@gmail.com.

