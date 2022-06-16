<template>
  <v-container>
    <h2>Krabbels</h2>

    <div class="krabbel-list" >
      <krabbel-component></krabbel-component>
      <krabbel-component></krabbel-component>
      <krabbel-component></krabbel-component>
      <krabbel-component></krabbel-component>
      <krabbel-component></krabbel-component>
      <krabbel-component></krabbel-component>
      <krabbel-component></krabbel-component>
      <krabbel-component></krabbel-component>
      <krabbel-component></krabbel-component>
    </div>
    <krabbel-form></krabbel-form>
  </v-container>
</template>

<script>
import KrabbelComponent from './KrabbelComponent.vue'
import KrabbelForm from './KrabbelForm.vue'
  export default {
    name: 'KrabbelSectionComponent',
    components: {
      KrabbelComponent,
        KrabbelForm
    },
  }
</script>

<style scoped>
  .krabbel-list {
    height: 400px;
    overflow: scroll;
  }

  ::-webkit-scrollbar {
    display: none;
  }
</style>
