<template>
  <div class="home">
    <div class="md-layout md-alignment-center">
      <h1>Noticias de Deportes</h1>
    </div>

    <div
      style="width:75%;margin: auto; padding-top:2rem"
      class="md-layout md-alignment-center"
    >
      <cardNew />
      <cardNew />
      <cardNew />
      <cardNew />
      <cardNew />
      <cardNew />
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import cardNew from '@/components/cardnew.vue'

export default {
  name: 'NewsByCategorie',
  components: {
    cardNew,
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
