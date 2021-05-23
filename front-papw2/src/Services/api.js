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
  // EditNew------------------------------------------------------------------------
  editNew(
    iD_Noticia,
    paisF,
    ciudadF,
    coloniaF,
    fecha_Hora_Acontecimiento,
    titulo_Noticia,
    descripcion_Noticia,
    texto_Noticia,
    palabra_Clave,
    seccion_Noticia,
    estatus_Noticia,
    comentarios_editor,
    TokenAccess
  ) {
    let editnew = {
      paisF,
      ciudadF,
      coloniaF,
      fecha_Hora_Acontecimiento,
      titulo_Noticia,
      descripcion_Noticia,
      texto_Noticia,
      palabra_Clave,
      seccion_Noticia,
      estatus_Noticia,
      comentarios_editor,
    }
    return axios.put(ENDPOINT_PATH + 'Noticias/update/' + iD_Noticia, editnew, {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + TokenAccess,
      },
    })
  },
  // DeleteNew --------------------------------------------------------------------------
  deleteNew(iD_Noticia, TokenAccess) {
    return axios.delete(ENDPOINT_PATH + 'Noticias/delete/' + iD_Noticia, {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + TokenAccess,
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
  // Create a coment ----------------------------------------------------------------
  createComent(texto, que_Noticia, TokenAccess) {
    let newNew = {
      texto,
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
  // Create a new Seccion ------------------------------------------------------------
  createSeccion(nombre_Seccion, TokenAccess) {
    let newSeccion = {
      nombre_Seccion,
      color: 2,
    }
    return axios.post(ENDPOINT_PATH + 'Secciones/Create/', newSeccion, {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + TokenAccess,
      },
    })
  },
  deleteSeccion(iD_seccion, TokenAccess) {
    return axios.delete(ENDPOINT_PATH + 'Secciones/Delete/' + iD_seccion, {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
        Authorization: 'Bearer ' + TokenAccess,
      },
    })
  },
}
