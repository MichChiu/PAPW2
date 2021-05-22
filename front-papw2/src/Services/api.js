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
  // New New
  createNew(
    paisF,
    ciudadF,
    coloniaF,
    fecha_Hora_Acontecimiento,
    autor,
    titulo_Noticia,
    descripcion_Noticia,
    texto_Noticia,
    palabra_Clave,
    seccion_Noticia,
    estatus_Noticia,
    comentarios_editor,
    TokenAccess
  ) {
    let newNew = {
      paisF,
      ciudadF,
      coloniaF,
      fecha_Hora_Acontecimiento,
      autor,
      titulo_Noticia,
      descripcion_Noticia,
      texto_Noticia,
      palabra_Clave,
      seccion_Noticia,
      estatus_Noticia,
      comentarios_editor,
    }
    return axios.post(ENDPOINT_PATH + 'Noticias/create', newNew, {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + TokenAccess,
      },
    })
  },
  getAllNoticias(AccesToken) {
    return axios.get(ENDPOINT_PATH + 'Noticias/Get', {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + AccesToken,
      },
    })
  },
  // GetSecciones------------------------------------------------------------------
  getAllSecci(AccesToken) {
    return axios.get(ENDPOINT_PATH + 'Secciones/Get', {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + AccesToken,
      },
    })
  },
  // GetAllComents
  getAllComents(AccesToken) {
    return axios.get(ENDPOINT_PATH + 'Comentarios/Get', {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + AccesToken,
      },
    })
  },

  createComent(texto, autor, que_Noticia, TokenAccess) {
    let newNew = {
      texto,
      autor,
      que_Noticia,
      TokenAccess,
    }
    return axios.post(ENDPOINT_PATH + 'Comentarios/create', newNew, {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + TokenAccess,
      },
    })
  },
}
