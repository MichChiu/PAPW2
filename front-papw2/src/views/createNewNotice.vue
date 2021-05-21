<template>
  <div>
    <md-card-content>
      <!-- Nombres y apellido -->
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label for="first-name">Titulo de la noticia:</label>
            <md-input v-model="noticeTitle" />
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label for="last-name">Descripcion Noticia:</label>
            <md-input v-model="noticeDescription" />
          </md-field>
        </div>
      </div>
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <div class="md-layout md-alignment-center">
            <md-field style="width:75%">
              <label>Texto de la noticia</label>
              <md-textarea v-model="noticeContent"></md-textarea>
            </md-field>
          </div>

          <md-field>
            <label for="age">Palabra clave</label>
            <md-input v-model="noticeClave" />
          </md-field>
        </div>
      </div>
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label>Pais</label>
            <md-select v-model="noticePais">
              <md-option value="1">Mexico</md-option>
              <md-option value="2">Estados Unidos</md-option>
              <md-option value="3">Canada</md-option>
            </md-select>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label>Ciudad</label>
            <md-select v-if="noticePais == 1" v-model="noticeCiudad">
              <md-option value="1">Monterrey</md-option>
              <md-option value="2">CDMX</md-option>
              <md-option value="3">Guadalajara</md-option>
            </md-select>
            <md-select v-else-if="noticePais == 2" v-model="noticeCiudad">
              <md-option value="4">Washington</md-option>
              <md-option value="5">New York</md-option>
              <md-option value="6">Los Angeles</md-option>
            </md-select>
            <md-select v-else v-model="noticeCiudad">
              <md-option value="7">Toronto</md-option>
              <md-option value="8">Vancouver</md-option>
            </md-select>
          </md-field>
        </div>
      </div>
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label>Seccion</label>
            <md-select v-model="noticeSeccion">
              <md-option value="1">Editor</md-option>
              <md-option value="2">Usuario</md-option>
              <md-option value="3">Reportero</md-option>
            </md-select>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label>Colonia</label>
            <md-select
              v-if="noticeCiudad == 1 || noticeCiudad == 2 || noticeCiudad == 3"
              v-model="noticeColonia"
            >
              <md-option value="1">Cumbres</md-option>
            </md-select>
            <md-select
              v-if="noticeCiudad == 4 || noticeCiudad == 5 || noticeCiudad == 6"
              v-model="noticeColonia"
            >
              <md-option value="2">Avenue</md-option>
              <md-option value="3">York New</md-option>
            </md-select>
            <md-select
              v-if="noticeCiudad == 7 || noticeCiudad == 8"
              v-model="noticeColonia"
            >
              <md-option value="4">Dowtown</md-option>
            </md-select>
          </md-field>
        </div>
      </div>
    </md-card-content>
    <md-card-actions class="md-layout md-alignment-center">
      <md-button style="background-color: cadetblue;" @click="callPrueba"
        >Create Notice</md-button
      >
    </md-card-actions>
  </div>
</template>
<script>
import service from '../Services/api'
export default {
  name: 'NuevaNotica',
  data: () => ({
    noticeTitle: '',
    noticeDescription: '',
    noticeContent: '',
    noticeClave: '',
    noticePais: '',
    noticeCiudad: '',
    noticeSeccion: '',
    noticeColonia: '',
    barer: localStorage.getItem('barerToken'),
  }),
  methods: {
    async callPrueba() {
      try {
        let response = await service.getAllSecci(this.barer)
        console.log(response.data, response)
        // watch.sessionActive = true
      } catch (error) {
        console.log(error)
      }
    },
  },
  async mounted() {
    try {
      let response = await service.getAllSecci(this.barer)
      console.log(response.data)
    } catch (err) {
      console.log(err)
    }
  },
}
</script>
