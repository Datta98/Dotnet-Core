# Dependency Injection In DotNet Core

- ASP.NET Core is designed from scratch to support Dependency Injection.
- ASP.NET Core injects objects of dependency classes through constructor or method by using built-in  container.

### Service Lifetime
- Built-in container manages the lifetime of a registered service type. It automatically disposes a service instance based on the specified lifetime.
#### The built-in  container supports three kinds of lifetimes:
**1) Singleton:** container will create and share a single instance of a service throughout the application's lifetime.<br>
```C# 
// Syntax
services.AddSingleton(typeof(IUserRepository), typeof(UserORMRepository));
```
**2) Transient:** The container will create a new instance of the specified service type every time you ask for it.<br>
```C# 
// Syntax
services.AddTransient(typeof(IUserRepository), typeof(UserORMRepository));
```
**3) Scoped:** container will create an instance of the specified service type once per request and will be shared in a single request.
```C# 
// Syntax
services.AddScoped(typeof(IUserRepository), typeof(UserORMRepository));
```
