



### Manage NuGet packages Dependencies by structure
<details><summary>Clean Archirecture</summary>
<p>

#### Ordering.Domain Layer
```powershell
MediatR
``` 

#### Presentation Layer
```powershell
Microsoft.Extensions.DependencyInjection.Abstractions
``` 

#### Instrastructure Layer
```powershell
Microsoft.Data.SqlClient
``` 

```powershell
Microsoft.Extensions.Configuration.Abstractions
``` 
```powershell
Microsoft.Extensions.DependencyInjection.Abstractions
``` 
</p>
</details> 

<details><summary>BuildBlocks Project</summary>
<p>
  
```powershell
Microsoft.Extensions.DependencyInjection.Abstractions
``` 
```powershell
MediatR
``` 
```powershell
Mapster
``` 
```powershell
FluentValidation.DependencyInjectionExtensions
``` 
```powershell
FluentValidation
``` 

</p>
</details> 

### DB & Schemas Scripts

<details><summary>Creame Schema Ordering </summary>
<p>
CREATE SCHEMA Ordering
</p>
