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
            <label for="email">UserName</label>
            <md-input type="email" name="email" id="email" />
          </md-field>
          <md-field>
            <label for="email">Contraseña</label>
            <md-input type="password" name="password" id="password" />
          </md-field>
        </md-card-content>
        <md-card-actions>
          <md-button type="submit" class="md-primary">Okey!</md-button>
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
                />
              </md-field>
            </div>
          </div>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label for="email">Email</label>
                <md-input type="email" name="email" id="email" />
                <span class="md-error">The email is required</span>
                <span class="md-error">Invalid email</span>
              </md-field>

              <md-field>
                <label for="age">Telefono</label>
                <md-input type="tel" id="age" name="age" autocomplete="age" />
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
                />
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label>Perfil</label>
                <md-select>
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
                <md-input type="password" name="password" id="password" />
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100">
              <md-field>
                <label for="last-name">Validar contraseña:</label>
                <md-input type="password" name="password" id="password" />
              </md-field>
            </div>
          </div>
        </md-card-content>

        <!-- <md-progress-bar md-mode="indeterminate" /> -->

        <md-card-actions>
          <md-button type="submit" class="md-primary">Create user</md-button>
        </md-card-actions>
      </md-card>

      <md-snackbar>The user {{}} was saved with success!</md-snackbar>
    </form>
    <!-- <button @click="callGetUsers()">PRUEBA</button> -->
  </div>
</template>

<script>
import service from '../Services/api'
export default {
  name: 'FormValidation',
  data: () => ({
    createUser: false,
    login: false,
    change: false,
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
