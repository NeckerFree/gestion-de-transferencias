<a name="readme-top"></a>

<div align="center">
  <br/>

  <h3><b>Gestión de Transferencias</b></h3>

</div>

<!-- TABLE OF CONTENTS -->

# 📗 Table of Contents

- [📖 About the Project](#about-project)
  - [🛠 Built With](#built-with)
    - [Tech Stack](#tech-stack)
    - [Key Features](#key-features)
  - [🚀 Live Demo](#live-demo)
- [💻 Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Setup](#setup)
  - [Install](#install)
  - [Usage](#usage)
  - [Run tests](#run-tests)
  - [Deployment](#deployment)
- [👥 Authors](#authors)
- [🔭 Future Features](#future-features)
- [🤝 Contributing](#contributing)
- [⭐️ Show your support](#support)
- [🙏 Acknowledgements](#acknowledgements)
- [❓ FAQ (OPTIONAL)](#faq)
- [📝 License](#license)

<!-- PROJECT DESCRIPTION -->

# 📖 Gestion de Transferencias <a name="about-project"></a>


**Gestion de Transferencias** es r una API REST para gestionar transferencias de saldo.

## 🛠 Built With <a name="built-with"></a>

### Tech Stack <a name="tech-stack"></a>

<details>
  <summary>Backend</summary>
  <ul>
    <li>.NET Core Web API</li>
  </ul>
</details>

<details>
<summary>Database</summary>
  <ul>
    <li><a href="https://www.sqlite.org/">SqlLite</a></li>
  </ul>
</details>

<!-- Features -->

### Key Features <a name="key-features"></a>

- **Clean Architecture**
- **MediatR**
- **Code First**
- **FluentValidation**
- **Automapper**
- **Framework net9.0**
- 
<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LIVE DEMO -->

## 🚀 Live Demo <a name="live-demo"></a>


- [Live Demo Link](https://google.com)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## 💻 Getting Started <a name="getting-started"></a>

clonar el repositorio
```sh
  git clone https://github.com/NeckerFree/gestion-de-transferencias
```

### Prerequisites

Se requiere VS 2022

### Setup

SQlite Database Setup:
Step 1: create initial migration (Package Manager Console)
```sh
  dotnet ef migrations add InitialCreate --project GestionTransferencias.Persistence
```
Step 2: create the folder defined in AppDbContext for database ('C:/Database/')

Step 3: Execute the command to create and update database (Package Manager Console)
```sh
  dotnet ef database update --project GestionTransferencias.Persistence
```
### Install

Install this project with:
Build the api project 

```sh
  dotnet build
  dotnet run 
```
Open the URL https://localhost:7001/swagger/index.html para ver la documentación y ejecutar las operaciones CRUD

### Usage 
<p align="center">
  <img src="https://github.com/user-attachments/assets/c2ed4dfb-0ee2-496d-810c-ed393f72cb46" alt="1 Modelo de datos">
</p>
<p align="center">1. Modelo de dato</p>
![2 Gestion de Transferencias API](https://github.com/user-attachments/assets/f686e9ab-6d5c-44d5-a3b6-a9370e54e58d)

<p align="center">2. API Gestión de Transferencias</p>

![3 POST Crear Billetera](https://github.com/user-attachments/assets/c71d6a97-b1f4-4b99-8e1c-58e6dd7ca380)
<p align="center">3. POST Crear Billetera</p>

![4 GET Obtener todas las billeteras](https://github.com/user-attachments/assets/44fbe616-d39f-4234-9301-0696d6e809dd)
<p align="center">4. GET Obtener todas las Billeteras</p>

![5 Get Obtener todos los movimientos](https://github.com/user-attachments/assets/775efebf-3125-408f-a3f6-fe4fe9c2da6e)
<p align="center">5. GET Obtener todos los movimientos</p>

![6 POST Crear transaccion validaciones](https://github.com/user-attachments/assets/840c33b1-c710-419a-b661-fc948177a259)
<p align="center">6. POST Crear Transacción Validaciones</p>

![7 POST Crear transaccion resultado](https://github.com/user-attachments/assets/3b45b89d-d9eb-4da6-bfce-fd3247d052ae)
<p align="center">7. POST Crear Transacción Resultado</p>

![8 Persistencia en BD ](https://github.com/user-attachments/assets/3ebb41a3-9fc2-43af-adc8-30b36c0b47dd)
<p align="center">8. Persistencia en BD</p>

![9 GET Obtener Billetera vsalidaciones](https://github.com/user-attachments/assets/491dae7a-3438-4af9-be37-03b404680783)
<p align="center">9. Obtener Billetera Validaciones</p>

![10 Estructura Solución Gestión Transferencias](https://github.com/user-attachments/assets/d06f601d-d7a2-48ce-9e22-f25fc8d92b19)
<p align="center">10. Estructura Solución Gestión Transferencias</p>


### Run tests


### Deployment

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- AUTHORS -->

## 👥 Authors <a name="authors"></a>

👤 **Elio Cortés**

- GitHub: [@NeckerFree](https://github.com/NeckerFree)


<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- FUTURE FEATURES -->

## 🔭 Future Features <a name="future-features"></a>

- [ ] **Patrón Unit of Work**
- [ ] **Completar Pruebas Unitarias y de Integración**
- [ ] **Usar Redis**

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## 🤝 Contributing <a name="contributing"></a>

Contributions, issues, and feature requests are welcome!

Feel free to check the [issues page](../../issues/).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- SUPPORT -->

## ⭐️ Show your support <a name="support"></a>

If you like this project...

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGEMENTS -->

## 🙏 Acknowledgments <a name="acknowledgements"></a>


I would like to thank...

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- FAQ (optional) -->

## ❓ FAQ (OPTIONAL) <a name="faq"></a>

- **[1. ¿Cómo tu implementación puede ser escalable a miles de transacciones?]**
- La implementación en Clean Architecture escala mediante CQRS para separar consultas de comandos, permitiendo distribuir cargas. Se integra Redis para cachear respuestas frecuentes y RabbitMQ/Kafka para procesar transacciones asíncronamente. Las bases de datos usan sharding (particionamiento por región/usuario) y réplicas de lectura para equilibrar la carga. Kubernetes maneja el escalado automático de pods en la nube, mientras que API Gateway (como YARP) distribuye tráfico entre microservicios.
- **[2. ¿Cómo tu implementación asegura el principio de idempotencia?]**
- Se garantiza generando tokens únicos (Idempotency-Key) en cada petición POST/PUT. El backend verifica en Redis si ya procesó esa clave antes de ejecutar la transacción. Para operaciones críticas, la base de datos usa constraints UNIQUE en campos como transaction_id. Si se detecta un request duplicado, se retorna la respuesta cacheada en lugar de reprocesar, asegurando consistencia.
- **[3. ¿Cómo protegerías tus servicios para evitar ataques deDenegación de servicios, sql injection, CSRF?]**
- Para DoS/DDoS se implementa rate limiting (límite de peticiones por IP) y Cloudflare. SQL Injection se mitiga con ORMs (EF Core/Dapper) que parametrizan queries. Los tokens CSRF y políticas CORS estrictas protegen endpoints web, mientras que el encoding de datos (HtmlEncoder) neutraliza XSS. Auditorías continuas con OWASP ZAP validan vulnerabilidades.
- **[4. ¿Cuál sería tu estrategia para migrar un monolito amicroservicios?]**
- Se aplica el Strangler Pattern: primero se extraen servicios acoplables (pagos, notificaciones) como módulos independientes con su propia DB (usando CDC para sincronizar datos iniciales). Un API Gateway enruta tráfico gradualmente del monolito a los nuevos servicios. Eventos asíncronos (Kafka) mantienen consistencia durante la transición, minimizando impacto en usuarios.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->

## 📝 License <a name="license"></a>

This project is [MIT](./LICENSE) licensed.

_NOTE: we recommend using the [MIT license](https://choosealicense.com/licenses/mit/) - you can set it up quickly by [using templates available on GitHub](https://docs.github.com/en/communities/setting-up-your-project-for-healthy-contributions/adding-a-license-to-a-repository). You can also use [any other license](https://choosealicense.com/licenses/) if you wish._

<p align="right">(<a href="#readme-top">back to top</a>)</p>
