# Plataforma de Votación Comunitaria

## ¿Qué se van a encontrar en el proyecto?

En este proyecto, los lectores encontrarán el desarrollo de una innovadora plataforma de votación comunitaria, diseñada para empoderar a los residentes de diferentes barrios y comunas, permitiéndoles decidir sobre la ejecución de proyectos que impactarán directamente en su entorno. La plataforma tiene como objetivo democratizar el proceso de toma de decisiones a nivel comunitario, brindando una herramienta accesible y fácil de usar para todos los ciudadanos.

## ¿Por qué decidieron hacerlo y cuál es el impacto que va a tener?

Decidimos embarcarnos en este proyecto debido a la creciente necesidad de involucrar más activamente a la comunidad en las decisiones que afectan su vida diaria. En muchas ocasiones, los proyectos comunitarios son seleccionados sin consultar adecuadamente a los residentes, lo que puede resultar en una falta de aceptación o relevancia de las iniciativas implementadas. Al crear esta plataforma, pretendemos asegurar que los proyectos con mayor apoyo y pertinencia sean los que se lleven a cabo, reflejando verdaderamente las necesidades y deseos de la comunidad.

El impacto de esta plataforma es significativo. Primero, promueve la participación ciudadana y fortalece el sentido de pertenencia y responsabilidad comunitaria. Al permitir que los residentes voten por los proyectos, estamos fomentando una mayor transparencia y confianza en las autoridades locales. Además, este sistema tiene el potencial de mejorar la eficiencia y efectividad de los proyectos comunitarios, asegurando que los recursos se destinen a iniciativas que cuentan con el respaldo de la mayoría.

## Características del Proyecto

### Tecnologías Usadas
- **Backend:** ASP.NET Core
- **Base de Datos:** SQL Server, Entity Framework Core
- **Frontend:** HTML, CSS, JavaScript
- **Autenticación y Autorización:** Identity
- **Metodología de Desarrollo:** Ágil (Sprints Quincenales)
- **Tecnologías de la Nube:** Azure (App Services, Azure SQL Database, Azure Active Directory)

### Miembros del Equipo (Nombres de Usuario)
- **Backend Developer:** @DRACKSBOYVEVO
- **Frontend Developer:** @juliana7176, @RafaelMf-star, @jua986, @kamaitachi1
- **Database Specialist:** @DRACKSBOYVEVO
- **Project Manager:** @DRACKSBOYVEVO

### Arquitectura
La arquitectura del proyecto sigue un enfoque de capas, que separa las preocupaciones de la lógica de negocio, el acceso a datos y la interfaz de usuario. Esto facilita el mantenimiento y escalabilidad del sistema.

1. **Capa de Presentación:** HTML, CSS, JavaScript
2. **Capa de Aplicación:** ASP.NET Core
3. **Capa de Datos:** SQL Server con Entity Framework Core

### Comandos para Clonar y Ejecutar el Proyecto

1. **Clonar el repositorio:**
   
```bash
   git clone https://github.com/DRACKSBOYVEVO/WebTalentTech.git
   cd WebTalentTech
```

### Configurar la base de datos
1. Ejecuta las migraciones para crear la base de datos

```bash
dotnet ef database update
```

2. Iniciar el servidor Backend:

```bash
dotnet run
```

### Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o un pull request para discutir cualquier cambio que te gustaría hacer.

### Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.