<template>
    <div>
      <v-dialog
        v-model="dialog"
        persistent
        max-width="600px"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            color="primary"
            small
            v-bind="attrs"
            v-on="on"
          >
            Muziek toevoegen
          </v-btn>
        </template>
        <v-card>
          <v-card-title>
            <span class="headline">Muziek toevoegen</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-form
                ref="form"
                v-model="valid"
                lazy-validation
              >
                <v-row>
                  <v-col cols="12">
                    <v-text-field
                        label="Titel"
                        v-model="data.Title"
                        :rules="rules.Text"
                        required
                    ></v-text-field>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col cols="12">
                    <v-text-field
                        label="Artiest"
                        v-model="data.Artist"
                        :rules="rules.Text"
                        required
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-form>
            </v-container>
            <small>*verplicht veld</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="blue darken-1"
              text
              @click="dialog = false"
            >
              Sluiten
            </v-btn>
            <v-btn
              color="blue darken-1"
              text
              @click="changeTheme()"
            >
              Toevoegen
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
</template>

<script>
import { CREATE_SONG, GET_SONGS } from '../../store/actions.type'

export default {
  data(){
    return {
      dialog: false,
      valid: "",
      data: {
        Title: "",
        Artist: ""
      },
      rules: {
        Text: [
          v => !!v || 'Naam is verplicht',
          v => (v && v.length >= 4) || 'Moet langer dan 4 karakters zijn.',
        ]
      }
    }
  },
  methods: {
    changeTheme: function () {
      if(this.$refs.form.validate()) {
        
        this.$store.dispatch(CREATE_SONG, { userId: this.$route.params.id, song: this.data})
        setTimeout(() => {
          this.$store.dispatch(GET_SONGS, { userId: this.$route.params.id });
        }, 500);
        this.dialog = false
        //this.$refs.form.reset()
      }
    }
  }
}
</script>
