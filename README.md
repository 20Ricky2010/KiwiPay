# KiwiPay

## Requisitos

- Node.js (v16 o superior)
- npm (v8 o superior)
- .NET 6 SDK o superior
- Angular CLI (instalar con: npm install -g @angular/cli)

---

## 1. Backend (ASP.NET Core)

1. Abre una terminal y navega a la carpeta del backend (donde está la solución .sln y los proyectos de C#).
2. Restaura los paquetes y ejecuta el backend:

   dotnet restore  
   dotnet build  
   dotnet run  

   El backend debería iniciar en https://localhost:60909 (o el puerto configurado).

---

## 2. Frontend (Angular)

1. Abre otra terminal y navega a la carpeta KiwiPayFrontend:

   cd KiwiPayFrontend

2. Instala las dependencias:

   npm install
   (si no funciona usar npm install  --legacy-peer-deps o ejecutar npm install typescript@5.2 --save-dev antes del npm install)


3. Ejecuta la aplicación Angular:

   ng serve

   Por defecto, la app estará disponible en http://localhost:4200.

---

## 3. Uso

- Accede a http://localhost:4200 en tu navegador.
- Asegúrate de que el backend esté corriendo para que el frontend pueda comunicarse correctamente.

---

## Notas

- Si tienes problemas de CORS, revisa la configuración del backend para permitir peticiones desde http://localhost:4200.
- Si cambias el puerto del backend, actualiza la variable API_BASE en src/app/Core/services/api.config.ts del frontend.

---

## Scripts útiles

- Frontend:
  - npm start o ng serve — Inicia el servidor de desarrollo Angular.
- Backend:
  - dotnet run — Inicia el backend en modo desarrollo.
