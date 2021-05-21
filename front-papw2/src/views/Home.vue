<template>
  <div class="home">
    <img
      src="../assets/banner.jpg"
      alt="People"
      style="width: 100%; height:250px"
    />
    <div class="md-layout md-alignment-center">
      <router-link to="/NoticeByCategorie">
        <md-button class="md-raised md-accent">Deportes</md-button>
      </router-link>
      <md-button class="md-raised md-accent">Espectaculos</md-button>
      <md-button class="md-raised md-accent">Local</md-button>
      <md-button class="md-raised md-accent">Internacional</md-button>
      <md-button class="md-raised md-accent">Horoscopos</md-button>
    </div>

    <div class="md-layout md-alignment-center">
      <h2>ULTIMAS NOTICIAS</h2>
    </div>
    <div class="md-layout md-alignment-center">
      <cardNotice
        v-for="noticia in allnotices"
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
import cardNotice from '@/components/cardNotice.vue'
import service from '../Services/api'
export default {
  name: 'Home',
  components: {
    cardNotice,
  },
  data: () => ({
    allnotices: '',
    barer: localStorage.getItem('barerToken'),
  }),
  async mounted() {
    try {
      let response = await service.getAllNoticias(this.barer)
      console.log(response.data)
      this.allnotices = response.data
    } catch (err) {
      console.log(err)
    }
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
