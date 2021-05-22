<template>
  <div class="page-container md-layout-column">
    <md-toolbar class="md-primary">
      <md-button class="md-icon-button" @click="showNavigation = true">
        <md-icon>menu</md-icon>
      </md-button>
      <router-link to="/Home">
        <span class="md-title">Artic-Noticias</span>
      </router-link>
    </md-toolbar>

    <md-drawer :md-active.sync="showNavigation" md-swipeable>
      <md-toolbar class="md-transparent" md-elevation="0">
        <span class="md-title">Opciones</span>
      </md-toolbar>

      <md-list>
        <md-list-item>
          <md-icon>move_to_inbox</md-icon>
          <router-link to="/MyNews">
            <span class="md-list-item-text md-title" @click="editNewState"
              >Mis Noticias</span
            >
          </router-link>
        </md-list-item>

        <md-list-item>
          <md-icon>send</md-icon>
          <router-link to="/createNewnew">
            <span class="md-list-item-text md-title" @click="createNewState"
              >Crear Noticia</span
            >
          </router-link>
        </md-list-item>
        <md-list-item>
          <md-icon>send</md-icon>
          <router-link to="/seccionOptions">
            <span class="md-list-item-text md-title" @click="createNewState"
              >Crear Seccion</span
            >
          </router-link>
        </md-list-item>
        <md-list-item>
          <md-icon>send</md-icon>
          <router-link to="/seccionOptions">
            <span class="md-list-item-text md-title" @click="createNewState"
              >Eliminar seccion</span
            >
          </router-link>
        </md-list-item>
        <md-list-item>
          <md-icon>send</md-icon>
          <router-link to="/">
            <span class="md-list-item-text md-title" @click="resetStorage"
              >Cerrar Sesion</span
            >
          </router-link>
        </md-list-item>
      </md-list>
    </md-drawer>
    <router-view></router-view>
  </div>
</template>

<script>
// import watch from '../src/watch'
export default {
  name: 'Navbar',
  data: () => ({
    showNavigation: false,
    showSidepanel: false,
  }),
  methods: {
    createNewState() {
      localStorage.setItem('editNew', 1)
    },
    editNewState() {
      localStorage.setItem('editNew', 2)
    },
    resetStorage() {
      this.$swal({
        title: 'Nos vemos hasta la proxima',
        preConfirm: () => {
          localStorage.clear()
        },
      })
    },
  },
}
</script>

<style>
@import url('https://fonts.googleapis.com/css?family=Material+Icons');

.md-drawer {
  width: 230px;
  max-width: calc(100vw - 125px);
}
</style>
