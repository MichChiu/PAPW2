<template>
  <div>
    <md-card-content>
      <!-- Nombres y apellido -->
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label for="first-name">Titulo de la noticia:</label>
            <md-input v-model="newTitle" />
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label for="last-name">Descripcion Noticia:</label>
            <md-input v-model="newDescription" />
          </md-field>
        </div>
      </div>
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <div class="md-layout md-alignment-center">
            <md-field style="width:75%">
              <label>Texto de la noticia</label>
              <md-textarea v-model="newContent"></md-textarea>
            </md-field>
          </div>

          <md-field>
            <label for="age">Palabra clave</label>
            <md-input v-model="newClave" />
          </md-field>
        </div>
      </div>
      <div class="md-layout md-gutter">
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label>Pais</label>
            <md-select v-model="newPais">
              <md-option value="1">Mexico</md-option>
              <md-option value="2">Estados Unidos</md-option>
              <md-option value="3">Canada</md-option>
            </md-select>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label>Ciudad</label>
            <md-select v-if="newPais == 1" v-model="newCiudad">
              <md-option value="1">Monterrey</md-option>
              <md-option value="2">CDMX</md-option>
              <md-option value="3">Guadalajara</md-option>
            </md-select>
            <md-select v-else-if="newPais == 2" v-model="newCiudad">
              <md-option value="4">Washington</md-option>
              <md-option value="5">New York</md-option>
              <md-option value="6">Los Angeles</md-option>
            </md-select>
            <md-select v-else v-model="newCiudad">
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
            <md-select v-model="newSeccionValue">
              <md-option
                v-for="Seccion in newSeccion"
                :key="Seccion.iD_Seccion"
                :value="Seccion.iD_Seccion"
                >{{ Seccion.nombre_Seccion }}</md-option
              >
            </md-select>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100">
          <md-field>
            <label>Colonia</label>
            <md-select
              v-if="newCiudad == 1 || newCiudad == 2 || newCiudad == 3"
              v-model="newColonia"
            >
              <md-option value="1">Cumbres</md-option>
            </md-select>
            <md-select
              v-if="newCiudad == 4 || newCiudad == 5 || newCiudad == 6"
              v-model="newColonia"
            >
              <md-option value="2">Avenue</md-option>
              <md-option value="3">York New</md-option>
            </md-select>
            <md-select
              v-if="newCiudad == 7 || newCiudad == 8"
              v-model="newColonia"
            >
              <md-option value="4">Dowtown</md-option>
            </md-select>
          </md-field>
        </div>
      </div>
    </md-card-content>
    <md-card-actions class="md-layout md-alignment-center">
      <md-button
        style="background-color: cadetblue;"
        @click="callNew"
        v-if="stateNew == 1"
        >Create new</md-button
      >
      <md-button
        style="background-color: cadetblue;"
        @click="editNew"
        v-if="stateNew == 2"
        >Edit New</md-button
      >
    </md-card-actions>
  </div>
</template>

<script>
import service from '../Services/api'
export default {
  name: 'NuevaNotica',
  components: {},
  data: () => ({
    newTitle: '',
    newDescription: '',
    newContent: '',
    newClave: '',
    newPais: '',
    newCiudad: '',
    newSeccion: '',
    newSeccionValue: '',
    newColonia: '',
    barer: localStorage.getItem('barerToken'),
    stateNew: localStorage.getItem('editNew'),
    newEdit: [],
  }),
  methods: {
    async callNew() {
      try {
        await service.createNew(
          this.newPais,
          this.newCiudad,
          this.newColonia,
          '2021-01-04T17:16:40',
          this.newTitle,
          this.newDescription,
          this.newContent,
          this.newClave,
          this.newSeccionValue,
          '3',
          'Todo muy cool',
          this.barer
        )
        this.$swal({
          icon: 'success',
          title: 'Se creo con exito tu noticia!',
          preConfirm: () => {
            this.$router.push('/home')
          },
        })
      } catch (error) {
        this.$swal({
          icon: 'error',
          title: 'Oh no algo ocurrio vuelve a intentar',
          preConfirm: () => {},
        })
        console.log(error)
      }
    },
    async editNew() {
      try {
        await service.editNew(
          this.newEdit.iD_Noticia,
          this.newPais,
          this.newCiudad,
          this.newColonia,
          '2021-01-04T17:16:40',
          this.newTitle,
          this.newDescription,
          this.newContent,
          this.newClave,
          this.newSeccionValue,
          '3',
          'Todo muy cool',
          this.barer
        )
        this.$swal({
          icon: 'success',
          title: 'Se modifico con exito tu noticia!',
          preConfirm: () => {
            this.$router.push('/home')
          },
        })
        this.$router.push('/home')
      } catch (error) {
        this.$swal({
          icon: 'error',
          title: 'Oh no algo ocurrio vuelve a intentar',
          preConfirm: () => {},
        })
        console.log(error)
      }
    },
  },
  async mounted() {
    try {
      let response = await service.getAllSecci(this.barer)
      console.log(response.data)
      this.newSeccion = response.data
    } catch (err) {
      console.log(err)
    }
    const state = localStorage.getItem('editNew')
    if (state == 2) {
      this.newEdit = JSON.parse(localStorage.getItem('NoticiaEditar'))
      ;(this.newTitle = this.newEdit.titulo_Noticia),
        (this.newDescription = this.newEdit.descripcion_Noticia),
        (this.newContent = this.newEdit.texto_Noticia),
        (this.newClave = 'prueba'),
        (this.newPais = this.newEdit.paisF),
        (this.newCiudad = this.newEdit.ciudadF),
        (this.newSeccionValue = this.newEdit.seccion_Noticia),
        (this.newColonia = this.newEdit.coloniaF)
    }
    console.log(this.newEdit.iD_Noticia, 'od', this.editNew)
  },
}
</script>
