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
            Hobby toevoegen
          </v-btn>
        </template>
        <v-card>
          <v-card-title>
            <span class="headline">Hobby toevoegen</span>
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
                        label="Text"
                        v-model="data.Name"
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
import { CREATE_HOBBY, GET_HOBBIES } from '../../store/actions.type'

export default {
  data(){
    return {
      dialog: false,
      valid: "",
      data: {
        Name: ""
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
        
        this.$store.dispatch(CREATE_HOBBY, { userId: this.$route.params.id, hobby: this.data})
        setTimeout(() => {
          this.$store.dispatch(GET_HOBBIES, { userId: this.$route.params.id });
        }, 500);
        this.dialog = false
        //this.$refs.form.reset()
      }
    }
  }
}
</script>
