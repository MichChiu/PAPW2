<template>
  <div>
    <formantnew v-if="statePage == 1" />

    <formantnew v-if="statePage == 2" />
  </div>
</template>
<script>
import formantnew from '../components/NoticiaFormat'
export default {
  name: 'NuevaNotica',
  components: {
    formantnew,
  },
  data: () => ({
    statePage: 5,
  }),
  methods: {},
  mounted() {
    this.statePage = localStorage.getItem('editNew')
  },
}
</script>
