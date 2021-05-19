<template>
  <div class="home">
    <div class="md-layout md-alignment-center">
      <h1>Noticias de Deportes</h1>
    </div>

    <div
      style="width:75%;margin: auto; padding-top:2rem"
      class="md-layout md-alignment-center"
    >
      <cardNotice />
      <cardNotice />
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
  name: 'NoticesByCategorie',
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
