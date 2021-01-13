import axios from 'axios'

const SERVER_URL = 'http://localhost:42144/api';

const instance = axios.create({
  baseURL: SERVER_URL,
  timeout: 1000
});

export default {

  async execute(method, resource, data, config) {
    return instance({
      method:method,
      url: resource,
      data,
      ...config
    })
  },

  createNew(text, completed) {
    return this.execute('POST', 'todos', {title: text, completed: completed})
  },
  getAll() {
    return this.execute('GET','todos', null)
  },

  update(id, text, completed) {
    return this.execute('PUT', 'todos/' + id, { title: text, completed: completed })
  },

  delete(id) {
    return this.execute('DELETE', 'todos/'+id)
  }
}
