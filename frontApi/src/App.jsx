import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios'

function App() {
  const [Usuarios, setUsuarios] = useState([])

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('http://localhost:40397/api/User')
        setUsuarios(response.data)
      } catch (error) {
        console.error("Error al hacer la consulta", error)
      }
    }
    fetchData()
  }, [])

  return (
    <>
      <h1>Ejercicio servicios WEB</h1>
      <ul>
        {Usuarios.map(usuario =>(
          <li key={usuario.id}>
            <div>
              <h2>Datos</h2>
              <p>Documento: {usuario.document}</p>
              <p>Nombre: {usuario.name}</p>
              <p>Telefono: {usuario.phoneNumber}</p>
              <p>Correo: {usuario.mail}</p>
              <p>Ciudad: {usuario.city}</p>
              <p>Fecha Registro: {usuario.dateRegister}</p>
            </div>
          </li>
        ))}
      </ul>
    </>
  )
}

export default App
