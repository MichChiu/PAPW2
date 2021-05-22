<template>
  <div class="md-alignment-center">
    <div class="md-layout md-alignment-center" style=" padding-top: 1rem;">
      <md-button
        class="md-raised md-get-palette-color-green"
        @click="createSeccion()"
        >Crear Seccion</md-button
      >
      <md-button class="md-raised" @click="DeleteSeccion()"
        >Eliminar Seccion</md-button
      >
    </div>
    <form novalidate class="md-layout " v-if="login == true">
      <md-card class="md-layout-item md-size-70">
        <md-card-header>
          <div class="md-title">Crear Seccion</div>
        </md-card-header>
        <md-card-content>
          <md-field>
            <label>Seccion Nombre</label>
            <md-input v-model="seccionName" />
          </md-field>
        </md-card-content>
        <md-card-actions>
          <md-button @click="callCreateSeccion">Okey!</md-button>
        </md-card-actions>
      </md-card>
    </form>

    <div class="md-layout md-alignment-center" v-if="createUser == true">
      <md-card class="md-layout-item md-size-70 ">
        <md-card-header>
          <div class="md-title">¿Que seccion quiere eliminar?</div>
        </md-card-header>
        <md-card-actions class="md-layout md-alignment-center">
          <md-button
            v-for="seccion in allSeccion"
            :key="seccion.iD_Seccion"
            @click="callDeleteSeccion(seccion.iD_Seccion)"
            >{{ seccion.nombre_Seccion }}</md-button
          >
        </md-card-actions>
      </md-card>
    </div>
  </div>
</template>

<script>
import service from '../Services/api'
// import watch from '../src/watch'
export default {
  name: 'FormValidation',
  data: () => ({
    createUser: false,
    login: false,
    change: false,
    // Valores para crear user
    seccionName: '',
    barer: localStorage.getItem('barerToken'),
    allSeccion: [],
  }),
  methods: {
    createSeccion() {
      this.createUser = false
      this.login = true
    },
    DeleteSeccion() {
      this.createUser = true
      this.login = false
    },
    // Call to create new User -------------------------------------------------
    async callCreateSeccion() {
      try {
        await service.createSeccion(this.seccionName, this.barer)
        this.$swal({
          icon: 'success',
          title: 'Se creo una nueva seccion',
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
    async callDeleteSeccion(id_seccion) {
      try {
        await service.deleteSeccion(id_seccion, this.barer)
        this.$swal({
          icon: 'success',
          title: 'Se elimino la  seccion',
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
  },
  async mounted() {
    try {
      let response = await service.getAllSecci(this.barer)
      console.log(response.data)
      this.allSeccion = response.data
    } catch (err) {
      console.log(err)
    }
  },
}
</script>
<style scoped>
.md-progress-bar {
  position: absolute;
  top: 0;
  right: 0;
  left: 0;
}

.card-expansion {
  height: 480px;
}

.md-card {
  margin: 0 auto;
  margin-top: 3rem;
  margin-bottom: 3rem;
  display: inline-block;
  vertical-align: top;
}
</style>
