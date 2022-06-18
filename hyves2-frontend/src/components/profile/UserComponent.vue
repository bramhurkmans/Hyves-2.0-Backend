<template>
  <v-container>

        <v-img
        lazy-src="@/assets/default_profile_picture.jpeg"
        src="@/assets/default_profile_picture.jpeg"
        ></v-img>

        <p class="text-md-center">{{ user.firstName }} (666)</p>

        <v-list dense>
          <v-list-item-group
            color="primary"
          >
            <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/user1_add.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Voeg toe als vriend</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <!-- <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/user1_add.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Tik</v-list-item-title>
              </v-list-item-content>
            </v-list-item> -->
            <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/mail.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Bericht</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/forbidden.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Blokkeren</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <v-list-item>
              <v-list-item-icon>
                <v-img src="@/assets/icons/policeman.png"></v-img>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>Dit is niet OK!</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-group>
        </v-list>


    
  </v-container>
</template>

<script>
import { GET_USER_BY_ID } from '@/store/actions.type';
  export default {
    name: 'UserComponent',
    
    data() {
    return {}
    },
    created: function () {
      this.$store.dispatch(GET_USER_BY_ID, {userId: this.$route.params.id})
    },
    computed: {
      user() {
        return this.$store.getters.getUserById;
      }
    }
  }
</script>
