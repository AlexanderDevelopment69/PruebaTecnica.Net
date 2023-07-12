# PruebaTecnica.Net

C# .NET:
1.	Crea un proyecto de API en C# utilizando .NET 6 o 7. Define una clase Movie con propiedades como Id, Title, Director, Genre, etc.
2.	Configura la conexión a la base de datos SQLite en el archivo de configuración de la aplicación.
3.	Implementa un controlador de API para realizar las operaciones CRUD en la clase Movie, utilizando Entity Framework Core para interactuar con la base de datos.
4.	Utiliza atributos de enrutamiento para definir las rutas de los endpoints del controlador.
5.	Asegúrate de manejar adecuadamente los casos de error y devolver respuestas HTTP apropiadas, como códigos de estado y mensajes de error descriptivos.
Angular:
1.	Crea un proyecto de Angular utilizando la versión más reciente disponible.
2.	Implementa un servicio en Angular para realizar las solicitudes HTTP a la API de películas.
3.	Crea componentes para mostrar la lista de películas, ver detalles de una película, crear una nueva película, editar una película existente y confirmar la eliminación de una película.
4.	Utiliza enlace de datos y directivas de Angular para mostrar y editar los detalles de las películas en los componentes correspondientes.
5.	Agrega validaciones de formulario para los campos obligatorios al crear y editar películas, y muestra mensajes de error apropiados.
6.	Asegúrate de manejar las respuestas de la API correctamente, mostrando mensajes de éxito o error según corresponda.
SQLite:
1.	Agrega el paquete NuGet Microsoft.EntityFrameworkCore.SQLite al proyecto de C# para permitir el uso de SQLite como base de datos.
2.	Crea una clase DbContext que herede de DbContext de Entity Framework Core, y configura la conexión a la base de datos SQLite en el método OnConfiguring.
3.	Define un DbSet<Movie> en el DbContext para representar la tabla de películas en la base de datos.
4.	Utiliza el DbContext en el controlador de la API para realizar las operaciones CRUD en la base de datos SQLite.

