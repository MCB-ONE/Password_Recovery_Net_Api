 # Game Of Foodies API
- [Game Of Foodies API](#game-of-foodies-api)
  - [Auth](#auth)
    - [Registro](#registro)
      - [Registro Request](#registro-request)
      - [Registro Response](#registro-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)


## Auth

### Registro

```js
POST {{host}}/auth/registro
```
#### Registro Request 
```json
{
    "Nombre": "Usuario",
    "Apellido": "Test",
    "email": "usuario.test@gmail.com",
    "password": "usaurio.test1234$"
}
```
#### Registro Response
```js
200 OK
```
```json
{
    "id": "283e55c9-47bc-4f5c-bfa2-099e6e1cfa8d",
    "nombre": "Usuario",
    "apellido": "Test",
    "email": "usuario.test@gmail.com",
    "token": "ciOiJIU...IxMjM0N"
}
```

### Login

```js
POST {{host}}/auth/login
```
#### Login Request 
```json
{
    "email": "usuario.test@gmail.com",
    "password": "usaurio.test1234$"
}
```
#### Login Response
```js
200 OK
```
```json
{
    "id": "283e55c9-47bc-4f5c-bfa2-099e6e1cfa8d",
    "nombre": "Usuario",
    "apellido": "Test",
    "email": "usuario.test@gmail.com",
    "token": "ciOiJIU...IxMjM0N"
}
```
