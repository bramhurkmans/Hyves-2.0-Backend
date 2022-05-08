import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';

Vue.use(Vuetify);

export default new Vuetify({
    theme: {
        themes: {
          light: {
            primary: '#003399', //#fedc98
            secondary: '#fedc98', //#689bc5
            accent: '#689bc5', //#ffac09
            error: '#ffac09', //#b71c1c
          },
        },
      },
});
