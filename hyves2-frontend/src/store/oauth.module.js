import axios from 'axios'
import {
  GET_USER_INFO
} from "./actions.type";
import {
  SET_USER_INFO,
} from "./mutations.type";


const state = {
  user: {},
};

const getters = {
  userInfo: state => state.userInfo,
};

const actions = {
  async [GET_USER_INFO](context) {
    return new Promise((resolve, reject) => {        
        axios({url: `/oauth2/userinfo`, data: null, method: 'GET' })
        .then(resp => {
            context.commit(SET_USER_INFO, resp)
            resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  }
};

const mutations = {

  [SET_USER_INFO](state, data) {
    state.user = data;
  }
};

export default {
  state,
  actions,
  mutations,
  getters
};
