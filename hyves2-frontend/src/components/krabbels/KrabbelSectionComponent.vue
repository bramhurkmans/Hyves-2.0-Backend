<template>
  <v-container>
    <h2>Krabbels</h2>

    <div class="krabbel-list" >
      <v-card
        class="mx-auto"
        max-width="344"
        outlined
      >
        <v-list-item three-line  v-for="(krabbel) in krabbels" :key="krabbel.id">
          <v-avatar
            tile
            size="60"
          >
            <img
              alt="Avatar"
              src="@/assets/default_profile_picture.jpeg"
            >
          </v-avatar>
          <v-list-item-content>
            <v-list-item-title class="text-h5 mb-1">
              {{ krabbel.sender.firstName }} {{ krabbel.sender.lastName }}
            </v-list-item-title>
            <v-list-item-subtitle>{{ krabbel.text }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-card>
    </div>
    <krabbel-form></krabbel-form>
  </v-container>
</template>

<script>
import { GET_KRABBELS_BY_USER } from '@/store/actions.type'
import KrabbelForm from './KrabbelForm.vue'
  export default {
    name: 'KrabbelSectionComponent',
    components: {
      KrabbelForm
    },

    data() {
    return {}
    },
    created: function () {
      this.$store.dispatch(GET_KRABBELS_BY_USER, {userId: this.$route.params.id})
    },
    computed: {
      krabbels() {
        return this.$store.getters.getKrabbelsByUser;
      }
    }
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
