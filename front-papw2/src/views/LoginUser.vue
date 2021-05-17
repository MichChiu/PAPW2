<template>
  <div class="md-layout md-alignment-center">
    <form novalidate class="md-layout ">
      <md-card class="md-layout-item md-size-70">
        <md-card-header>
          <div class="md-title">Iniciar Sesion</div>
        </md-card-header>
        <md-card-content>
          <md-field>
            <label for="email">Email</label>
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
    <form novalidate class="md-layout">
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
                <label for="age">Telefono</label>
                <md-input type="tel" id="age" name="age" autocomplete="age" />
              </md-field>
            </div>
          </div>

          <md-field>
            <label for="email">Email</label>
            <md-input type="email" name="email" id="email" />
            <span class="md-error">The email is required</span>
            <span class="md-error">Invalid email</span>
          </md-field>
        </md-card-content>

        <!-- <md-progress-bar md-mode="indeterminate" /> -->

        <md-card-actions>
          <md-button type="submit" class="md-primary">Create user</md-button>
        </md-card-actions>
      </md-card>

      <md-snackbar>The user {{}} was saved with success!</md-snackbar>
    </form>
  </div>
</template>

<script>
export default {
  name: 'FormValidation',
  data: () => ({}),
  methods: {},
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
