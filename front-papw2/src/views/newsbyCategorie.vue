<template>
  <div class="home">
    <div class="md-layout md-alignment-center">
      <h1>Noticias de {{ nameSectionActive }}</h1>
    </div>

    <div
      style="width:75%;margin: auto; padding-top:2rem"
      class="md-layout md-alignment-center"
    >
      <cardNew
        v-for="noticeSection in seccionNews"
        :key="noticeSection.seccion_Noticia"
        :titulo_Noticia="noticeSection.titulo_Noticia"
        :seccion_Noticia="noticeSection.seccion_Noticia"
        :descripcion_Noticia="noticeSection.descripcion_Noticia"
        :iD_Noticia="noticeSection.iD_Noticia"
        :ciudadF="noticeSection.ciudadF"
        :coloniaF="noticeSection.coloniaF"
        :paisF="noticeSection.paisF"
        :texto_Noticia="noticeSection.texto_Noticia"
        :autor="noticeSection.autor"
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
    seccionNews: [],
    allNews: '',
    barer: localStorage.getItem('barerToken'),
    seccionActivate: localStorage.getItem('idSeccion'),
    nameSectionActive: localStorage.getItem('nameSeccion'),
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
      if (this.allNews[i].seccion_Noticia == this.seccionActivate) {
        this.seccionNews.push(this.allNews[i])
      }
    }
    console.log(this.seccionNews, 'seccion', this.seccionActivate)
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
