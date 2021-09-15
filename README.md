# Wiki 📖

## Objetivos 📋
Desarrollar un sistema, que permita la administración general de una Wiki (de cara a los administradores): Usuarios Autores, Articulos con Encabezados, cuerpo, Entradas, Referencias, Mensajes, etc., como así también, permitir a los usuarios Lectores, navegar la Wiki y enviar mensajes.
Utilizar Visual Studio 2019 preferentemente y crear una aplicación utilizando ASP.NET MVC Core 3.1.

<hr />

## Enunciado 📢
La idea principal de este trabajo práctico, es que Uds. se comporten como un equipo de desarrollo.
Este documento, les acerca, un equivalente al resultado de una primera entrevista entre el cliente y alguien del equipo, el cual relevó e identificó la información aquí contenida. 
A partir de este momento, deberán comprender lo que se está requiriendo y construir dicha aplicación, 

Deben recopilar todas las dudas que tengan y evacuarlas con su nexo (el docente) de cara al cliente. De esta manera, él nos ayudará a conseguir la información ya un poco más procesada. 
Es importante destacar, que este proceso, no debe esperar a ser en clase; es importante, que junten algunas consultas, sea de índole funcional o técnicas, en lugar de cada consulta enviarla de forma independiente.

Las consultas que sean realizadas por correo deben seguir el siguiente formato:

Subject: [NT1-<CURSO LETRA>-GRP-<GRUPO NUMERO>] <Proyecto XXX> | Informativo o Consulta

Body: 

1.<xxxxxxxx>

2.< xxxxxxxx>


# Ejemplo
**Subject:** [NT1-A-GRP-5] Agenda de Turnos | Consulta

**Body:**

1.La relación del paciente con Turno es 1:1 o 1:N?

2.Está bien que encaremos la validación del turno activo, con una propiedad booleana en el Turno?

<hr />

### Proceso de ejecución en alto nivel ☑️
 - Crear un nuevo proyecto en [visual studio](https://visualstudio.microsoft.com/en/vs/).
 - Adicionar todos los modelos dentro de la carpeta Models cada uno en un archivo separado.
 - Especificar todas las restricciones y validaciones solicitadas a cada una de las entidades. [DataAnnotations](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-3.1).
 - Crear las relaciones entre las entidades
 - Crear una carpeta Data que dentro tendrá al menos la clase que representará el contexto de la base de datos DbContext. 
 - Crear el DbContext utilizando base de datos en memoria (con fines de testing inicial). [DbContext](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1), [Database In-Memory](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=vs).
 - Agregar los DbSet para cada una de las entidades en el DbContext.
 - Crear el Scaffolding para permitir los CRUD de las entidades al menos solicitadas en el enunciado.
 - Aplicar las adecuaciones y validaciones necesarias en los controladores.  
 - Realizar un sistema de login con al menos los roles equivalentes a <Usuario Cliente> y <Usuario Administrador> (o con permisos elevados).
 - Si el proyecto lo requiere, generar el proceso de registración. 
 - Un administrador podrá realizar todas tareas que impliquen interacción del lado del negocio (ABM "Alta-Baja-Modificación" de las entidades del sistema y configuraciones en caso de ser necesarias).
 - El <Usuario Cliente> sólo podrá tomar acción en el sistema, en base al rol que tiene.
 - Realizar todos los ajustes necesarios en los modelos y/o funcionalidades.
 - Realizar los ajustes requeridos del lado de los permisos.
 - Todo lo referido a la presentación de la aplicaión (cuestiones visuales).
 
<hr />

## Entidades 📄

- Autor
- Articulo
- Encabezado
- Cuerpo
- Entrada
- Referencia
- Mensaje

`Importante: Todas las entidades deben tener su identificador unico. Id o <ClassNameId>`

`
Las propiedades descriptas a continuación, son las minimas que deben tener las entidades. Uds. pueden agregar las que consideren necesarias.
De la misma manera Uds. deben definir los tipos de datos asociados a cada una de ellas, como así también las restricciones.
`

**Autor**
```
- Nombre
- Apellido
- Email
- Telefono
- FechaAlta
- Password
- Articulos
```

**Articulo**
```
- Fecha
- Activo
- CategoriaPrincipal
- CategoriasSecundarias
- Autor
- Encabezado
- Cuerpo
- Referencias
- Mensajes
- PalabrasClave
```


**Categoria**
```
- Nombre
- Activa
- Descripcion
- Articulos
```

**Encabezado**
```
- Titulo
- Descripcion
- Articulo
```

**Cuerpo**
```
- Entradas
- Articulo
```

**Entrada**
```
- Orden
- Titulo
- Subtitulo
- Texto
- Cuerpo
```


**Referencia**
```
- ArticuloPrincipal
- ArticuloReferencial
```

**Mensaje**
```
- FechaYHora
- Articulo
- Usuario
- Titulo
- Texto
```

**PalabraClave**
```
- Palabra
- Articulos
```


**NOTA:** aquí un link para refrescar el uso de los [Data annotations](https://www.c-sharpcorner.com/UploadFile/af66b7/data-annotations-for-mvc/).

<hr />

## Caracteristicas y Funcionalidades ⌨️
`Todas las entidades, deben tener implementado su correspondiente ABM, a menos que sea implicito el no tener que soportar alguna de estas acciones.`

**Usuario**
- Los Usuarios pueden auto registrarse.
- La autoregistración desde el sitio, es exclusiva para los usuarios externos. Por lo cual, se le asignará dicho rol.
- Los administradores de la Wiki, deben ser agregados por otro Administrador.
	- Al momento, del alta del Administrador, se le definirá un username y password.
    - También se le asignará a estas cuentas el rol de Administrador.
- Los usuarios pueden navegar por la wiki y postear mensajes en los articulos.
- Pueden crear Articulos.
- Pueden solicitar la creación de un Categoria.
- Si ya existe una solicitud para esa categoría, se le debe informar.
- Se debe mostrar al usuario sus solicitudes de categorias, con su estado.

**Autor**
- Un Autor puede crear un articulo
    - El proceso será en modo Wizard.
        - Selecciona la categoria existente.
        -- Si no existe la categoria que quiere, puede solicitar la creación de una, mediante la carga una que no estará activa.
        --- El proceso será igual que la creación de una nueva categoria, con la diferencia de: 1. Estará desactivada, hasta que un administrador la active. 2. Quedará un registro del usuario solicitante, para notificarlo con el resultado de su solicitud. 
        - Puede seleccionar más categorias como secundarias.
        - Crea un encabezado con su contenido
        - Hasta aquí es lo minimo requerido para crear un articulo.
        - Luego se le consulta, si quiere crear una entrada en el Articulo.
        -- Al finalizar, le vuelve a consultar si quiere agregar más entradas y repetir el proceso.
        -- Cada entrada agregada, quedará debajo de la anterior al visualizarse en el articulo.
        - Puede agregar referencias a otros articulos de la wiki. Para ello, se le ofrecerá agregar referencias y mediante un buscador, podrá seleccionar articulos para generar una referencia.
        - También, podrá agregar palabras clave, que sirvan para que encuentren su articulo. Al agregar una palabra clave, buscará una similitud en la base de palabras y propondrá hasta 10, El autor puede seleccionar una o crear una.
        - El articulo estará por defecto desactivado.
- El Autor, puede activar y desactivar sus articulos cuando lo desee.
- Puede actualizar datos de contacto etc.

**Administrador**
- Un Administrador, puede crear Categorias.
- Un Administrador, puede desactivar articulos de los usuarios.
- Puede activar categorias propuestas por los usuarios.
- Puede crear palabras clave

**Articulo**
- El articulo tendrá una categoria principal, y puede tener categorias secundarias.
-- Un articulo, no puede tener dos veces una categoria como principal y como secundaria, o dos veces como secundaria. (No se puede repetir)
- El articulo cargará automaticamente la fecha de creación.
- Por defecto, los articulos estarán Inactivos, y por consiguiente, no estarán disponibles para ser visualizados y o encontrados por el buscador.
- Solo puede tener un Autor
- Solo puede tener un Encabezado
- Solo puede tener un Cuerpo, el cual podrá tener muchas entradas. Ordenadas, en el orden que se fueron agregando.
- Las Referencias, serán visualizadas como links, a otros articulos.
- Los Mensajes serán visualizados, en orden creciente por fecha de carga. 
- Las PalabrasClave, serviran para encontrar el articulo, y serán visualizadas también como links, a un listado de articulos relacionados.

**Aplicación General**
- La wiki, mostrará los encabezados en la home de los ultimos 4 articulos creados. Para que los usuarios puedan acceder a verlos.
- Se debe ofrecer también, navegación por categorias. 
- Se debe ofrecer un buscador, por palabras clave, que ofrecerá un listado sabana, de articulos relacionados. Hasta 10.
- Se debe listar el top 3 de autores con más articulos.
- Los usuarios no pueden eliminar los articulos, solo pueden deshabilitarse.
- Los administradores, si pueden eliminar los articulos.
- Los accesos a las funcionalidades y/o capacidades, debe estar basada en los roles que tenga cada individuo.


