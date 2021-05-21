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
        <router-link to="/ReadNotice">
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
    noticiaAct: '',
    prueba: 'me piro',
    barer: localStorage.getItem('barerToken'),
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
      localStorage.setItem('NoticiaActiva', JSON.stringify(noticiaActiva))
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
