<template>
  <div class="page-container">
    <md-app>
      <md-app-toolbar class="md-primary">
        <span class="md-title">{{ showNotice.titulo_Noticia }}</span>
      </md-app-toolbar>

      <!-- Sidebar informacion del usuario / autor de la noticia -->

      <md-app-content>
        <div class="md-layout md-alignment-center">
          <md-card-media>
            <img src="../assets/noticia2.jpg" style="width:85%; " />
          </md-card-media>
        </div>
        <p>
          {{ showNotice.texto_Noticia }}
        </p>
        <h3 style="padding-top:3rem">
          COMENTARIOS---------------------------------
        </h3>

        <div
          style="padding-top:0rem"
          v-for="comentario in thisComents"
          :key="comentario.iD_Comentarios"
        >
          <md-divider></md-divider>
          <md-card-header-text style="padding-top:15px;padding-bottom:20px">
            <div>
              <div class="md-title">{{ comentario.texto }}</div>
              <div class="md-subhead">{{ comentario.autor }}</div>
            </div>
          </md-card-header-text>
          <md-divider></md-divider>
        </div>
        <h3 style="padding-top:2rem">
          ¡No te vayas sin dejar tu comentario!
        </h3>
        <div class="md-layout md-alignment-center">
          <md-field style="width:75%">
            <label>Textarea</label>
            <md-textarea v-model="comentText"></md-textarea>
          </md-field>
        </div>
        <div class="md-layout md-alignment-center">
          <md-button class="md-dense md-raised md-primary" @click="addComent"
            >Comentar</md-button
          >
        </div>
      </md-app-content>

      <md-app-drawer md-permanent="full">
        <md-list>
          <md-list-item>
            <span class="md-list-item-text">Autor:</span>
            <span class="md-list-item-text">{{ showNotice.autor }}</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Seccion:</span>
            <span class="md-list-item-text">{{
              showNotice.seccion_Noticia
            }}</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Ciudad:</span>
            <span class="md-list-item-text">{{ showNotice.ciudadF }}</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Colonia:</span>
            <span class="md-list-item-text">{{ showNotice.coloniaF }}</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Pais:</span>
            <span class="md-list-item-text">{{ showNotice.paisF }}</span>
          </md-list-item>

          <md-list-item>
            <span class="md-list-item-text">Fecha:</span>
            <span class="md-list-item-text">{{ showNotice.Fecha }}</span>
          </md-list-item>
        </md-list>
      </md-app-drawer>
    </md-app>
  </div>
</template>

<script>
import service from '../Services/api'
export default {
  name: 'AllNotice',
  components: {},
  data: () => ({
    barer: localStorage.getItem('barerToken'),
    showNotice: '',
    comentsall: '',
    thisComents: [],
    comentText: '',
  }),
  async mounted() {
    this.showNotice = JSON.parse(localStorage.getItem('NoticiaActiva'))
    // this.showNotice = JSON.parse(this.showNotice)
    console.log(this.showNotice, 'hola')
    console.log(this.showNotice.autor, 'datoespecifico')

    try {
      let response = await service.getAllComents(this.barer)
      console.log(response.data)
      this.comentsall = response.data
    } catch (err) {
      console.log(err)
    }

    for (var i = 0; i < this.comentsall.length; i++) {
      // console.log(this.comentsall[i])
      if (this.comentsall[i].que_Noticia === this.showNotice.iD_Noticia) {
        this.thisComents.push(this.comentsall[i])
      }
    }
    // console.log( this.thisComents,'Coments de esta')

    console.log(this.thisComents, 'comentarios de esta noticia')
  },
  methods: {
    async addComent() {
      try {
        await service.createComent(
          this.comentText,
          '89f4483d-1681-4ec0-9909-1a896fe6c863',
          this.showNotice.iD_Noticia,
          this.barer
        )
        location.reload()
      } catch (error) {
        console.log(error)
      }
    },
  },
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
