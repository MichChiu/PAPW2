import axios from 'axios'

const ENDPOINT_PATH = 'https://localhost:5001/api/'

export default {
  createNewUser(
    nombre,
    apellido,
    correoE,
    contraseña,
    nombreUsuario,
    telefono,
    perfil
  ) {
    let newUser = {
      nombre,
      apellido,
      correoE,
      contraseña,
      nombreUsuario,
      telefono,
      perfil,
    }

    let config = {
      headers: {
        'Access-Control-Allow-Origin': '*',
      },
    }
    return axios.post(ENDPOINT_PATH + 'Usuarios/Create', newUser, config)
  },
  getAllUsers() {
    // let config = {
    //   headers: {
    //     'Access-Control-Allow-Origin': '*',
    //   },
    // }
    // return axios({
    //   method: 'get', //you can set what request you want to be
    //   url: ENDPOINT_PATH + 'Usuarios/Get',
    //   headers: {
    //     'Access-Control-Allow-Origin': '*',
    //   },
    // })
     return axios.post(ENDPOINT_PATH + 'Usuarios/Get')
  },
}
