<template>
  <div class="page-container">
    <md-app>
      <md-app-toolbar class="md-primary">
        <span class="md-title">Titulo de la noticia</span>
      </md-app-toolbar>

      <!-- Sidebar informacion del usuario / autor de la noticia -->

      <md-app-content>
        <div class="md-layout md-alignment-center">
          <md-card-media>
            <img src="../assets/noticia2.jpg" style="width:85%; " />
          </md-card-media>
        </div>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error
          quibusdam, non molestias et! Earum magnam, similique, quo recusandae
          placeat dicta asperiores modi sint ea repudiandae maxime? Quae non
          explicabo, neque.
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error
          quibusdam, non molestias et! Earum magnam, similique, quo recusandae
          placeat dicta asperiores modi sint ea repudiandae maxime? Quae non
          explicabo, neque.
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error
          quibusdam, non molestias et! Earum magnam, similique, quo recusandae
          placeat dicta asperiores modi sint ea repudiandae maxime? Quae non
          explicabo, neque.
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error
          quibusdam, non molestias et! Earum magnam, similique, quo recusandae
          placeat dicta asperiores modi sint ea repudiandae maxime? Quae non
          explicabo, neque.
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error
          quibusdam, non molestias et! Earum magnam, similique, quo recusandae
          placeat dicta asperiores modi sint ea repudiandae maxime? Quae non
          explicabo, neque.
        </p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error
          quibusdam, non molestias et! Earum magnam, similique, quo recusandae
          placeat dicta asperiores modi sint ea repudiandae maxime? Quae non
          explicabo, neque.
        </p>
        <h3 style="padding-top:3rem">
          COMENTARIOS---------------------------------
        </h3>

        <div style="padding-top:0rem">
          <md-divider></md-divider>
          <md-card-header-text style="padding-top:15px;padding-bottom:20px">
            <div class="md-title">Comentario</div>
            <div class="md-subhead">Autor del comentario</div>
          </md-card-header-text>
          <md-divider></md-divider>
        </div>
        <h3 style="padding-top:2rem">
          ¡No te vayas sin dejar tu comentario!
        </h3>
        <div class="md-layout md-alignment-center">
          <md-field style="width:75%">
            <label>Textarea</label>
            <md-textarea v-model="textarea"></md-textarea>
          </md-field>
        </div>
        <div class="md-layout md-alignment-center">
          <md-button class="md-dense md-raised md-primary">Comentar</md-button>
        </div>
      </md-app-content>

      <md-app-drawer md-permanent="full">
        <md-list>
          <md-list-item>
            <span class="md-list-item-text">Autor:</span>
            <span class="md-list-item-text">Autor:</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Seccion:</span>
            <span class="md-list-item-text">Seccion:</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Ciudad:</span>
            <span class="md-list-item-text">Ciudad:</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Colonia:</span>
            <span class="md-list-item-text">Colonia:</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Pais:</span>
            <span class="md-list-item-text">Pais:</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Fecha:</span>
            <span class="md-list-item-text">Fecha:</span>
          </md-list-item>
        </md-list>
      </md-app-drawer>
    </md-app>
  </div>
</template>

<script>
export default {
  name: 'Normal',
}
</script>

<style>
.md-app {
  border: 1px solid rgba(#000, 0.12);
}

.md-drawer {
  width: 230px;
  max-width: calc(100vw - 125px);
}
</style>
