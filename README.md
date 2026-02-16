# CourseraFullStackIntegration
Project: Building and Deploying the Full-Stack Integration Project

## Project Overview

A full-stack .NET solution with two main components:
- **Client**: Blazor WebAssembly app (ClientAppdotnet)
- **Server**: ASP.NET Core Web API (ServerApp)

### Initial Setup
- [x] Solution and projects (.sln, .csproj files)
- [x] Client app with Razor components, layouts, and CSS
- [x] Server app configuration with appsettings
- [x] Launch settings for debugging
- [x] Build outputs and static web assets

### Objective
Enable the Blazor client to fetch and manage products from the server API with full CRUD functionality.

### Key Features Implemented

#### Client-Side (Blazor WebAssembly)
- **FetchProducts.razor**: HTTP client integration with error handling
- **Product Management**: Add, edit, delete operations with forms
- **Data Display**: Bootstrap-styled table with product details
- **Validation**: DataAnnotations for form validation with user feedback
- **Navigation**: Updated menu with inventory management link

#### Server-Side (ASP.NET Core)
- **CRUD Endpoints**: Full `/api/products` implementation
- **CORS Configuration**: Enabled for localhost development
- **Performance**: IMemoryCache for optimized data retrieval
- **Data Storage**: Local JSON file persistence
- **Models**: Product and Category classes with serialization

### Result
✅ Full-stack CRUD inventory application with modern UI, proper validation, and optimized performance