export default {
  install: (Vue) => {
    Vue.config.globalProperties.$cover = (state) => {
      if (state) {
        const element = document.createElement('div')
        element.classList.add('cover--global')
        document.body.appendChild(element)
      } else {
        document.querySelector('.cover--global').remove()
      }
    }
  }
}
