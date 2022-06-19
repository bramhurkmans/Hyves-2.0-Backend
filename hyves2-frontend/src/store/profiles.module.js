import axios from 'axios'
import { CREATE_HOBBY, CREATE_SONG, DELETE_HOBBY, DELETE_SONG, GET_HOBBIES, GET_SONGS, GET_THEME } from "./actions.type";
import {
  SET_HOBBIES,
  SET_SONGS,
  SET_THEME,
} from "./mutations.type";


const state = {
  songs: [],
  hobbies: [],
  theme: {}
};

const getters = {
  getHobbies: state => state.hobbies,
  getSongs: state => state.songs,
  getTheme: state => state.theme,
};

const actions = {
  async [GET_THEME](context, { userId }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/${userId}/themes`, data: null, method: 'GET' })
        .then(resp => {
            context.commit(SET_THEME, resp.data)
            resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [GET_HOBBIES](context, { userId }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/${userId}/hobbies`, data: null, method: 'GET' })
        .then(resp => {
            context.commit(SET_HOBBIES, resp.data.data)
            resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [CREATE_HOBBY](context, { hobby }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/0/hobbies`, data: hobby, method: 'POST' })
        .then(resp => {
          resolve(resp);
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [DELETE_HOBBY](context, { hobbyId }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/0/hobbies/${hobbyId}`, data: null, method: 'DELETE' })
        .then(resp => {
          resolve(resp);
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [GET_SONGS](context, { userId }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/${userId}/songs`, data: null, method: 'GET' })
        .then(resp => {
            context.commit(SET_SONGS, resp.data.data)
            resolve(resp)
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [CREATE_SONG](context, { song }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/0/songs`, data: song, method: 'POST' })
        .then(resp => {
          resolve(resp);
        })
        .catch(err => {
            reject(err)
        })
    })
  },
  async [DELETE_SONG](context, { songId }) {
    return new Promise((resolve, reject) => {        
        axios({url: `/api/profiles/0/songs/${songId}`, data: null, method: 'DELETE' })
        .then(resp => {
          resolve(resp);
        })
        .catch(err => {
            reject(err)
        })
    })
  }
};

const mutations = {
  [SET_HOBBIES](state, data) {
    state.hobbies = data;
  },
  [SET_SONGS](state, data) {
    state.songs = data;
  },
  [SET_THEME](state, data) {
    state.theme = data;
  },
};

export default {
  state,
  actions,
  mutations,
  getters
};
