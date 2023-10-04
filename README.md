# 🍕 Pizza Maker Application

## Overview

The Pizza Maker Application allows users to select their desired pizza size and toppings to create a customized pizza. Users can also view a list of all placed pizza orders.

## 🌟 Features

- **Create a customized pizza order**
- **View a list of all pizza orders**
- **Fetch available pizza sizes and toppings**
- **Calculate the total cost of a pizza based on size and toppings**
- **Display success and error notifications using toasts**

## 🔧 Usage

### API Endpoints

- **Pizza Sizes**: `GET /api/v1/orders/available-sizes`
- **Pizza Toppings**: `GET /api/v1/orders/available-toppings`
- **Place Order**: `POST /api/v1/orders`
- **Get All Orders**: `GET /api/v1/orders`
- **Calculate Cost**: `POST /api/v1/orders/calculate-cost`

### Frontend

- Navigate to `/create-pizza` to create a new pizza order.
- Navigate to `/order-list` to view a list of all placed pizza orders.

## 🛠️ Technologies Used

### Frontend:

- **React**: A JavaScript library for building user interfaces.
- **Redux & Redux Toolkit**: State management tools for React.
- **Vite**: Build tool and development server.
- **react-redux-toastr**: Toast library for Redux.
- **@mui/material**: Material-UI components for React.

### Backend:

- **.NET 7**: Framework for building web APIs.
- **Entity Framework Core**: Object-Relational Mapper (ORM) for .NET.
- **FluentValidation**: A library for building strongly-typed validation rules.
- **AutoMapper**: An object-object mapper for .NET.
- **Swashbuckle**: Swagger toolchain for .NET.

### Testing:

- **xUnit**: Testing tool for .NET.
- **Moq**: Mocking framework for .NET.
- **coverlet.collector**: Code coverage collector for .NET.

## 📐 Design Patterns and Practices

- **Repository Pattern**: Abstracts the data layer, providing a cleaner separation of concerns and better code maintainability.
- **Middleware Pattern**: Custom middleware (ExceptionMiddleware) for global exception handling in the backend.
- **Unit of Work Pattern**: Consolidates transactional jobs into a single unit to ensure that all operations either pass or fail as one.
- **Error Boundary in React**: A React component that catches JavaScript errors anywhere in their child component tree, logs those errors, and displays a fallback UI.
- **Thunk Pattern with Redux**: Allows dispatching functions (thunks) that perform asynchronous logic and can dispatch actions based on the outcome of that logic.
- **Dependency Injection**: Built-in .NET dependency injection used to provide services and configuration to the application.

## 🚀 Getting Started

### Frontend:

1. Navigate to the `client_app` directory.
2. Install the dependencies with `npm install`.
3. Start the development server with `npm run dev`.

### Backend:

1. Ensure you have the .NET 7 SDK installed.
2. Navigate to the `backend` directory.
3. Run the API using `dotnet run`.

### Testing

For backend tests, navigate to the test project directory and run `dotnet test` to execute all unit tests.