import axios from 'axios'

const ENDPOINT_PATH = 'https://localhost:5001/api/'

export default {
  // CreateNewUSer ---------------------------------------------------------
  createNewUser(
    nombre,
    apellido,
    Email,
    userName,
    PhoneNumber,
    perfil,
    Password
  ) {
    let newUser = {
      nombre,
      apellido,
      userName,
      Email,
      PhoneNumber,
      perfil,
      Password,
    }
    return axios.post(ENDPOINT_PATH + 'security/createUser', newUser)
  },
  // Login  -----------------------------------------------------------------
  loginUser(userName, Password) {
    let loginUser = {
      userName,
      Password,
    }
    return axios.post(ENDPOINT_PATH + 'security/login', loginUser)
  },
  // GetSecciones------------------------------------------------------------------
  getAllSecci(AccesToken) {
    console.log(AccesToken, 'aca le llega')
    // let config = {
    //   headers: { Authorization: `Bearer ${AccesToken}` },
    // }
    // return axios({
    //   method: 'get', //you can set what request you want to be
    //   url: ENDPOINT_PATH + 'Usuarios/Get',
    //   config,
    // })
    return axios.get(ENDPOINT_PATH + 'Secciones/Get', {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + AccesToken,
      },
    })
  },
}
