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

        <!-- <md-list-item>
          <md-icon>delete</md-icon>
          <span class="md-list-item-text">Trash</span>
        </md-list-item>

        <md-list-item>
          <md-icon>error</md-icon>
          <span class="md-list-item-text">Spam</span>
        </md-list-item> -->
      </md-list>
    </md-drawer>
    <router-view></router-view>
    <!-- <md-drawer class="md-right" :md-active.sync="showSidepanel" md-swipeable>
      <md-toolbar class="md-transparent" md-elevation="0">
        <span class="md-title">Favorites</span>
      </md-toolbar>

      <md-list>
        <md-list-item>
          <span class="md-list-item-text">Abbey Christansen</span>

          <md-button class="md-icon-button md-list-action">
            <md-icon class="md-primary">chat_bubble</md-icon>
          </md-button>
        </md-list-item>

        <md-list-item>
          <span class="md-list-item-text">Alex Nelson</span>

          <md-button class="md-icon-button md-list-action">
            <md-icon class="md-primary">chat_bubble</md-icon>
          </md-button>
        </md-list-item>

        <md-list-item>
          <span class="md-list-item-text">Mary Johnson</span>

          <md-button class="md-icon-button md-list-action">
            <md-icon>chat_bubble</md-icon>
          </md-button>
        </md-list-item>
      </md-list>
    </md-drawer> -->
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
