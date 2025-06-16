openapi: 3.0.0
info:
  title: Webstore API
  version: 1.0.0
  description: API for managing users, products, orders, and login.

servers:
  - url: https://localhost:7020

paths:
  /login:
    post:
      summary: Login with email
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/Login'
      responses:
        '200':
          description: Successful login
          content:
            application/json:
              schema:
                type: object
                properties:
                  userId:
                    type: integer
                  token:
                    type: string

  /users:
    get:
      summary: Get all users
      responses:
        '200':
          description: List of users
          content:
            application/json:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/User'
    post:
      summary: Create a new user
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/User'
      responses:
        '201':
          description: User created

  /users/{id}:
    get:
      summary: Get a user by ID
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      responses:
        '200':
          description: User found
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/User'
    put:
      summary: Update a user
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/User'
      responses:
        '200':
          description: User updated
    delete:
      summary: Delete a user
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      responses:
        '204':
          description: User deleted

  /products:
    get:
      summary: Get all products
      responses:
        '200':
          description: List of products
          content:
            application/json:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/Product'
    post:
      summary: Create a new product
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/Product'
      responses:
        '201':
          description: Product created

  /products/{id}:
    get:
      summary: Get product by ID
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      responses:
        '200':
          description: Product found
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Product'
    put:
      summary: Update a product
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/Product'
      responses:
        '200':
          description: Product updated
    delete:
      summary: Delete a product
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      responses:
        '204':
          description: Product deleted

  /orders:
    get:
      summary: Get all orders
      responses:
        '200':
          description: List of orders
          content:
            application/json:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/Order'
    post:
      summary: Create a new order
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/Order'
      responses:
        '201':
          description: Order created

  /orders/{id}:
    get:
      summary: Get order by ID
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      responses:
        '200':
          description: Order found
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Order'
    put:
      summary: Update an order
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      requestBody:
        required: true
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/Order'
      responses:
        '200':
          description: Order updated
    delete:
      summary: Delete an order
      parameters:
        - in: path
          name: id
          required: true
          schema:
            type: integer
      responses:
        '204':
          description: Order deleted

components:
  schemas:
    Login:
      type: object
      properties:
        email:
          type: string

    User:
      type: object
      properties:
        id:
          type: integer
        firstName:
          type: string
        lastName:
          type: string
        email:
          type: string
        phoneNumber:
          type: string
        address:
          type: string

    Product:
      type: object
      properties:
        id:
          type: integer
        name:
          type: string
        description:
          type: string
        category:
          type: string
        price:
          type: number
          format: double
        isAvailable:
          type: boolean

    OrderItem:
      type: object
      properties:
        id:
          type: integer
        orderId:
          type: integer
        productId:
          type: integer
        quantity:
          type: integer

    Order:
      type: object
      properties:
        id:
          type: integer
        userId:
          type: integer
        user:
          $ref: '#/components/schemas/User'
        orderItems:
          type: array
          items:
            $ref: '#/components/schemas/OrderItem'
