<template>
  <div class="home">
    <img
      src="../assets/banner.jpg"
      alt="People"
      style="width: 100%; height:250px"
    />
    <div class="md-layout md-alignment-center">
      <router-link to="/NewByCategorie">
        <md-button
          class="md-raised md-accent"
          v-for="seccion in allSecciones"
          :key="seccion.iD_Seccion"
          @click="wichSection(seccion.iD_Seccion, seccion.nombre_Seccion)"
          >{{ seccion.nombre_Seccion }}</md-button
        >
      </router-link>
    </div>

    <div class="md-layout md-alignment-center">
      <h2>ULTIMAS NOTICIAS</h2>
    </div>
    <div class="md-layout md-alignment-center">
      <cardNew
        v-for="noticia in allNews"
        :key="noticia.iD_Noticia"
        :titulo_Noticia="noticia.titulo_Noticia"
        :seccion_Noticia="noticia.seccion_Noticia"
        :descripcion_Noticia="noticia.descripcion_Noticia"
        :iD_Noticia="noticia.iD_Noticia"
        :ciudadF="noticia.ciudadF"
        :coloniaF="noticia.coloniaF"
        :paisF="noticia.paisF"
        :texto_Noticia="noticia.texto_Noticia"
        :autor="noticia.autor"
      />
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import cardNew from '@/components/cardnew.vue'
import service from '../Services/api'
export default {
  name: 'Home',
  components: {
    cardNew,
  },
  data: () => ({
    allNews: '',
    allSecciones: [],
    barer: localStorage.getItem('barerToken'),
  }),

  methods: {
    wichSection(id, name) {
      localStorage.setItem('idSeccion', id)
      localStorage.setItem('nameSeccion', name)
    },
  },
  async mounted() {
    try {
      let response = await service.getAllNoticias(this.barer)
      console.log(response.data)
      this.allNews = response.data
    } catch (err) {
      console.log(err)
    }
    try {
      let response = await service.getAllSecci(this.barer)
      console.log(response.data)
      this.allSecciones = response.data
    } catch (err) {
      console.log(err)
    }
    localStorage.setItem('editNew', 0)
    console.log(this.allSecciones, 'secciones')
  },
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
