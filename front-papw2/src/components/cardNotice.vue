<template>
  <div>
    <md-card>
      <md-card-media>
        <img src="../assets/noticia1.jpg" alt="People" />
      </md-card-media>

      <md-card-header>
        <div class="md-title">Titulo Mamadon</div>
        <div class="md-subhead">Categoria</div>
      </md-card-header>

      <md-card-content>
        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Optio itaque
        ea, nostrum odio. Dolores, sed accusantium quasi non, voluptas eius
        illo.
      </md-card-content>
      <md-card-actions>
        <router-link to="/ReadNotice">
          <md-button>Leer mas..</md-button>
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
  components: {
    // HelloWorld,
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
