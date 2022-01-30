

## Code First Approach example

![enter image description here](https://lh3.googleusercontent.com/MLCvZpdxjJ4tV2_Wd75vQebHgJX2AC4exb5qxhGB55lXM3wjCwev3aUBKJyAuYyd3eoIKhsIjrI1lpNwgmdy=w1920-h977-rw)

Basic Implementation of crud using the code first approach

Using the following tech and practices
 - Entity Framework Core
 - Mediatr
 - CQRS
 - Dependency Injection (Inversion of control principle)
 - Swagger Docs
 - .Net Core 5 

------------


Run the following commands to migrate to your **MySQL** database

**Initialize migration**
`package manager console > Add-Migration DBinit`

**Bind entities to MySQL Database**
`package manager console > Update-Database`