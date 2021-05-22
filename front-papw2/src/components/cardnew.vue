<template>
  <div>
    <md-card>
      <md-card-media>
        <img src="../assets/noticia1.jpg" alt="People" />
      </md-card-media>

      <md-card-header>
        <div class="md-title">{{ titulo_Noticia }}</div>
        <div class="md-subhead">{{ seccion_Noticia }}</div>
      </md-card-header>

      <md-card-content> {{ descripcion_Noticia }} </md-card-content>
      <md-card-actions>
        <div v-if="stateNew == 2">
          <md-button
            class="md-icon-button"
            @click="
              clickNoticia(
                titulo_Noticia,
                seccion_Noticia,
                descripcion_Noticia,
                iD_Noticia,
                ciudadF,
                coloniaF,
                paisF,
                texto_Noticia,
                autor
              )
            "
          >
            <router-link to="/createNewnew">
              <md-icon>move_to_inbox</md-icon>
            </router-link>
          </md-button>
          <md-button class="md-icon-button">
            <md-icon>delete</md-icon>
          </md-button>
        </div>
        <router-link to="/Readnew">
          <md-button
            @click="
              clickNoticia(
                titulo_Noticia,
                seccion_Noticia,
                descripcion_Noticia,
                iD_Noticia,
                ciudadF,
                coloniaF,
                paisF,
                texto_Noticia,
                autor
              )
            "
            >Leer mas..</md-button
          >
        </router-link>
      </md-card-actions>
    </md-card>
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  components: {},
  props: [
    'titulo_Noticia',
    'seccion_Noticia',
    'descripcion_Noticia',
    'iD_Noticia',
    'ciudadF',
    'coloniaF',
    'paisF',
    'texto_Noticia',
    'autor',
  ],
  data: () => ({
    barer: localStorage.getItem('barerToken'),
    stateNew: localStorage.getItem('editNew'),
  }),
  methods: {
    clickNoticia(
      titulo_Noticia,
      seccion_Noticia,
      descripcion_Noticia,
      iD_Noticia,
      ciudadF,
      coloniaF,
      paisF,
      texto_Noticia,
      autor
    ) {
      let noticiaActiva = {
        titulo_Noticia,
        seccion_Noticia,
        descripcion_Noticia,
        iD_Noticia,
        ciudadF,
        coloniaF,
        paisF,
        texto_Noticia,
        autor,
      }
      if (this.stateNew == 2) {
        localStorage.setItem('NoticiaEditar', JSON.stringify(noticiaActiva))
      } else {
        localStorage.setItem('NoticiaActiva', JSON.stringify(noticiaActiva))
      }
      console.log('datos', noticiaActiva)
    },
  },
  mounted() {},
}
</script>

<style>
.md-card {
  width: 320px;
  margin: 4px;
  display: inline-block;
  vertical-align: top;
}
</style>
