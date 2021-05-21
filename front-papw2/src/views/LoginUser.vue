<template>
  <div class="md-alignment-center">
    <div class="md-layout md-alignment-center" style=" padding-top: 1rem;">
      <md-button
        class="md-raised md-get-palette-color-green"
        @click="createStateUser()"
        >Crear Usuario</md-button
      >
      <md-button class="md-raised" @click="LoginStateUser()"
        >Iniciar Sesion</md-button
      >
    </div>
    <form novalidate class="md-layout " v-if="login == true">
      <md-card class="md-layout-item md-size-70">
        <md-card-header>
          <div class="md-title">Iniciar Sesion</div>
        </md-card-header>
        <md-card-content>
          <md-field>
            <label>UserName</label>
            <md-input name="userName" v-model="userUserName" />
          </md-field>
          <md-field>
            <label>Contraseña</label>
            <md-input
              type="password"
              name="password"
              id="password"
              v-model="userContra"
            />
          </md-field>
        </md-card-content>
        <md-card-actions>
          <md-button @click="callLoginUSer">Okey!</md-button>
        </md-card-actions>
      </md-card>
    </form>
    <form
      novalidate
      class="md-layout"
      v-if="createUser == true"
      style=" padding-top: 0px"
    >
      <md-card class="md-layout-item md-size-70">
        <md-card-header>
          <div class="md-title">Nuevo Usuario</div>
        </md-card-header>

        <md-card-content>
          <!-- Nombres y apellido -->
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label for="first-name">Nombre:</label>
                <md-input
                  name="first-name"
                  id="first-name"
                  autocomplete="given-name"
                  v-model="userNombre"
                />
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label for="last-name">Apellido</label>
                <md-input
                  name="last-name"
                  id="last-name"
                  autocomplete="family-name"
                  v-model="userApellido"
                />
              </md-field>
            </div>
          </div>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label for="email">Email</label>
                <md-input
                  type="email"
                  name="email"
                  id="email"
                  v-model="userEmail"
                />
              </md-field>

              <md-field>
                <label for="age">Telefono</label>
                <md-input
                  type="tel"
                  id="age"
                  name="age"
                  autocomplete="age"
                  v-model="userTelefono"
                />
              </md-field>
            </div>
          </div>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label for="first-name">UserName:</label>
                <md-input
                  name="first-name"
                  id="first-name"
                  autocomplete="given-name"
                  v-model="userUserName"
                />
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label>Perfil</label>
                <md-select v-model="userPerfil">
                  <md-option value="1">Editor</md-option>
                  <md-option value="2">Usuario</md-option>
                  <md-option value="3">Reportero</md-option>
                </md-select>
              </md-field>
            </div>
          </div>

          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label for="first-name">Contraseña:</label>
                <md-input
                  type="password"
                  name="password"
                  id="password"
                  v-model="userContra"
                />
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label for="last-name">Validar contraseña:</label>
                <md-input
                  type="password"
                  name="password"
                  id="password"
                  v-model="userContraConfirm"
                />
              </md-field>
            </div>
          </div>
        </md-card-content>

        <!-- <md-progress-bar md-mode="indeterminate" /> -->

        <md-card-actions>
          <md-button @click="callCreateUSer">Create user</md-button>
        </md-card-actions>
      </md-card>
    </form>
    <!-- <button @click="callGetUsers()">PRUEBA</button> -->
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
    userNombre: '',
    userApellido: '',
    userUserName: '',
    userEmail: '',
    userTelefono: '',
    userPerfil: '',
    userContra: '',
    userContraConfirm: '',
    result: '',
  }),
  methods: {
    async callGetUsers() {
      try {
        let response = await service.getAllUsers()
        console.log(response.data, 'data')
      } catch (error) {
        console.log(error, 'errorr')
      }
    },
    createStateUser() {
      this.createUser = true
      this.login = false
    },
    LoginStateUser() {
      this.createUser = false
      this.login = true
    },
    // Call to create new User -------------------------------------------------
    async callCreateUSer() {
      try {
        await service.createNewUser(
          this.userNombre,
          this.userApellido,
          this.userEmail,
          this.userUserName,
          this.userTelefono,
          this.userPerfil,
          this.userContra
        )
        this.login = true
        this.createUser = false
      } catch (error) {
        console.log(error)
      }
    },

    // Call to login user -----------------------------------------------
    async callLoginUSer() {
      try {
        let response = await service.loginUser(
          this.userUserName,
          this.userContra
        )
        console.log(response.data, response)
        localStorage.setItem('barerToken', response.data)
        localStorage.setItem('userActive', this.userUserName)
        localStorage.setItem('activateSession', 1)
        this.$router.push('/home')
        // watch.sessionActive = true
      } catch (error) {
        console.log(error)
      }
    },
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

async register() { try { await auth.register(this.email, this.password);
this.$router.push("/") } catch (error) { console.log(error); } }
