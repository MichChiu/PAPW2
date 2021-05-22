<template>
  <div class="home">
    <div class="md-layout md-alignment-center">
      <h1>Mis Noticias</h1>
    </div>

    <div
      style="width:75%;margin: auto; padding-top:2rem"
      class="md-layout md-alignment-center"
    >
      <cardNew
        v-for="noticia in myNews"
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
  name: 'NewsByCategorie',
  components: {
    cardNew,
  },
  data: () => ({
    myNews: [],
    allNews: '',
    barer: localStorage.getItem('barerToken'),
    userActivade: '440e3b21-f0a5-4b32-8848-dc5017c47424',
  }),
  async mounted() {
    try {
      let response = await service.getAllNoticias(this.barer)
      console.log(response.data)
      this.allNews = response.data
    } catch (err) {
      console.log(err)
    }
    for (var i = 0; i < this.allNews.length; i++) {
      if (this.allNews[i].autor == this.userActivade) {
        this.myNews.push(this.allNews[i])
      }
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
