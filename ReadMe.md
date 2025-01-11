# Amazon Clone Backend (C# WebAPI)

## **Tech Stack**

- **Framework**: .NET 8.0 (C# WebAPI)
- **Database**: MySQL
- **ORM**: Entity Framework Core (Pomelo MySQL Provider)
- **Tools**:
  - Swagger for API documentation
  - Postman for testing

## **Project Structure**

```
backend/
│
├── Controllers/
│   ├── ProductsController.cs      # Handles product-related API requests
│   ├── UsersController.cs         # Handles user registration and login
│   └── OrdersController.cs        # Handles order-related API requests
│
├── Models/
│   ├── Product.cs                 # Product data model
│   ├── User.cs                    # User data model
│   └── Order.cs                   # Order and OrderItem data models
│
├── Data/
│   └── AppDbContext.cs            # Database context for Entity Framework Core
│
├── Program.cs                     # Main entry point of the application
├── appsettings.json               # Configuration file for database connection
└── appsettings.Development.json   # Development-specific configuration
```

## **API Endpoints**

### **Products Endpoints**

| HTTP Method | Endpoint        | Description             |
| ----------- | --------------- | ----------------------- |
| `GET`       | `/api/products` | Retrieves all products. |
| `GET`       | `/api/products/{id}` | Retrieves a specific product by ID. |
| `GET`       | `/api/products/{id}/items` | Retrieves all order items for a specific product by ID. |
| `POST`      | `/api/products` | Creates a new product.  |
| `PUT`       | `/api/products/{id}` | Updates a specific product by ID. |
| `DELETE`    | `/api/products/{id}` | Deletes a specific product by ID. |

#### **Examples**

- **GET `/api/products`**
  - **Response**:
    ```json
    [
      {
        "id": 1,
        "name": "Product 1",
        "description": "Description 1",
        "price": 99.99,
        "imageUrl": "http://example.com/product1.jpg",
        "stock": 10
      }
    ]
    ```

- **GET `/api/products/{id}`**
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "Product 1",
      "description": "Description 1",
      "price": 99.99,
      "imageUrl": "http://example.com/product1.jpg",
      "stock": 10
    }
    ```

- **POST `/api/products`**
  - **Request Body**:
    ```json
    {
      "name": "Product 2",
      "description": "Description 2",
      "price": 49.99,
      "imageUrl": "http://example.com/product2.jpg",
      "stock": 20
    }
    ```
  - **Response**:
    ```json
    {
      "id": 2,
      "name": "Product 2",
      "description": "Description 2",
      "price": 49.99,
      "imageUrl": "http://example.com/product2.jpg",
      "stock": 20
    }
    ```

- **PUT `/api/products/{id}`**
  - **Request Body**:
    ```json
    {
      "name": "Updated Product",
      "description": "Updated Description",
      "price": 79.99,
      "imageUrl": "http://example.com/updatedproduct.jpg",
      "stock": 15
    }
    ```
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "Updated Product",
      "description": "Updated Description",
      "price": 79.99,
      "imageUrl": "http://example.com/updatedproduct.jpg",
      "stock": 15
    }
    ```

- **DELETE `/api/products/{id}`**
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "Product 1",
      "description": "Description 1",
      "price": 99.99,
      "imageUrl": "http://example.com/product1.jpg",
      "stock": 10
    }
    ```

### **Users Endpoints**

| HTTP Method | Endpoint           | Description           |
| ----------- | ------------------ | --------------------- |
| `GET`       | `/api/users`       | Retrieves all users.  |
| `GET`       | `/api/users/{id}`  | Retrieves a specific user by ID. |
| `POST`      | `/api/users`       | Registers a new user. |
| `POST`      | `/api/users/login` | Logs in a user.       |
| `PUT`       | `/api/users/{id}`  | Updates a specific user by ID. |
| `DELETE`    | `/api/users/{id}`  | Deletes a specific user by ID. |


#### **Examples**

- **GET `/api/users`**
  - **Response**:
    ```json
    [
      {
        "id": 1,
        "name": "John Doe",
        "email": "john@example.com"
      }
    ]
    ```

- **GET `/api/users/{id}`**
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "John Doe",
      "email": "john@example.com"
    }
    ```

- **POST `/api/users`**
  - **Request Body**:
    ```json
    {
      "name": "John Doe",
      "email": "john@example.com",
      "password": "password123"
    }
    ```
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "John Doe",
      "email": "john@example.com"
    }
    ```
- **POST `/api/users/login`**
  - **Request Body**:
    ```json
    {
      "email": "john@example.com",
      "password": "password123"
    }
    ```
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "John Doe",
      "email": "john@example.com"
    }
    ```

- **PUT `/api/users/{id}`**
  - **Request Body**:
    ```json
    {
      "name": "John Doe",
      "email": "john@example.com",
      "password": "newpassword123"
    }
    ```
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "John Doe",
      "email": "john@example.com"
    }
    ```

- **DELETE `/api/users/{id}`**  
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "John Doe",
      "email": "john@example.com"
    }
    ```

### **Orders Endpoints**

| HTTP Method | Endpoint      | Description         |
| ----------- | ------------- | ------------------- |
| `GET`       | `/api/orders` | Retrieves all orders. |
| `GET`       | `/api/orders/{id}` | Retrieves a specific order by ID. |
| `GET`       | `/api/orders/{id}/items` | Retrieves items for a specific order by ID. |
| `GET`       | `/api/orders/{id}/user` | Retrieves the user associated with a specific order by ID. |
| `POST`      | `/api/orders` | Places a new order. |
| `POST`      | `/api/orders/{id}/items` | Adds items to a specific order by ID. |
| `PUT`       | `/api/orders/{id}` | Updates a specific order by ID. |
| `DELETE`    | `/api/orders/{id}` | Deletes a specific order by ID. |

#### **Examples**

- **GET `/api/orders`**
  - **Response**:
    ```json
    [
      {
        "id": 1,
        "userId": 1,
        "items": [
          { "id": 1, "productId": 1, "quantity": 2, "price": 50.0 },
          { "id": 2, "productId": 2, "quantity": 1, "price": 30.0 }
        ],
        "totalPrice": 130.0
      }
    ]
    ```

- **GET `/api/orders/{id}`**
  - **Response**:
    ```json
    {
      "id": 1,
      "userId": 1,
      "items": [
        { "id": 1, "productId": 1, "quantity": 2, "price": 50.0 },
        { "id": 2, "productId": 2, "quantity": 1, "price": 30.0 }
      ],
      "totalPrice": 130.0
    }
    ```

- **GET `/api/orders/{id}/items`**
  - **Response**: 
    ```json
    [
      { "id": 1, "productId": 1, "quantity": 2, "price": 50.0 },
      { "id": 2, "productId": 2, "quantity": 1, "price": 30.0 }   
    ]
    ```

- **GET `/api/orders/{id}/user`**
  - **Response**:
    ```json
    {
      "id": 1,
      "name": "John Doe",
      "email": "john@example.com"
    }
    ```

- **POST `/api/orders`**
  - **Request Body**:
    ```json
    {
      "userId": 1,
      "items": [
        { "productId": 1, "quantity": 2, "price": 50.0 },
        { "productId": 2, "quantity": 1, "price": 30.0 }
      ],
      "totalPrice": 130.0
    }
    ```
  - **Response**:
    ```json
    {
      "id": 1,
      "userId": 1,
      "items": [
        { "id": 1, "productId": 1, "quantity": 2, "price": 50.0 },
        { "id": 2, "productId": 2, "quantity": 1, "price": 30.0 }
      ],
      "totalPrice": 130.0
    }
    ```


- **POST `/api/orders/{id}/items`**
  - **Request Body**:
    ```json
    {
      "productId": 3,
      "quantity": 1,
      "price": 20.0
    }
    ```
  - **Response**:
    ```json
    {
      "id": 1,
      "userId": 1,
      "items": [
        { "id": 1, "productId": 1, "quantity": 2, "price": 50.0 },
        { "id": 2, "productId": 2, "quantity": 1, "price": 30.0 },
        { "id": 3, "productId": 3, "quantity": 1, "price": 20.0 }
      ],
      "totalPrice": 130.0
    }
    ```

- **PUT `/api/orders/{id}`**
  - **Request Body**:
    ```json
    {
      "userId": 1,
      "items": [
        { "productId": 1, "quantity": 2, "price": 50.0 },
        { "productId": 2, "quantity": 1, "price": 30.0 }
      ],
      "totalPrice": 130.0
    }
    ```
  - **Response**:
    ```json
    {
      "id": 1,
      "userId": 1,
      "items": [
        { "id": 1, "productId": 1, "quantity": 2, "price": 50.0 },
        { "id": 2, "productId": 2, "quantity": 1, "price": 30.0 }
      ],
      "totalPrice": 130.0
    }
    ```

- **DELETE `/api/orders/{id}`**
  - **Response**:
    ```json
    {
      "id": 1,
      "userId": 1,
      "items": [
        { "id": 1, "productId": 1, "quantity": 2, "price": 50.0 },
        { "id": 2, "productId": 2, "quantity": 1, "price": 30.0 }
      ],
      "totalPrice": 130.0
    }
    ```

## **Setup Instructions**

1. Clone the repository:

   ```bash
   git clone <repository-url>
   cd backend
   ```

2. Install dependencies:

   ```bash
   dotnet restore
   ```

3. Create a `.env` file in the root directory:

   ```env
   DB_HOST=localhost
   DB_PORT=3306
   DB_NAME=AmazonCloneDB
   DB_USER=root
   DB_PASSWORD=yourpassword
   ```

4. Update `Program.cs` to load environment variables:

   ```csharp
   var builder = WebApplication.CreateBuilder(args);

   // Load environment variables
   DotNetEnv.Env.Load();

   var connectionString = $"Server={Environment.GetEnvironmentVariable("DB_HOST")};" +
                          $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
                          $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                          $"User={Environment.GetEnvironmentVariable("DB_USER")};" +
                          $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};";

   builder.Services.AddDbContext<AppDbContext>(options =>
       options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
   ```

5. Create and apply migrations:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

6. Run the application:

   ```bash
   dotnet run
   ```

7. Access the API at `http://localhost:5071`.
