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
      <cardNotice />
      <cardNotice />
      <cardNotice />
      <cardNotice />
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import cardNotice from '@/components/cardNotice.vue'

export default {
  name: 'Home',
  components: {
    cardNotice,
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
