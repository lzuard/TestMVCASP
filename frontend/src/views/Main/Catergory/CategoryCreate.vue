<template>
  <showcase-create
    v-bind="createData"
    @onSend="createCategory($event)"
    ref="form"
  />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'CategoryCreate',
  components: {
    ShowcaseCreate
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать категорию',
        fields: [
          {
            label: 'Название категории',
            placeholder: 'Имя',
            modelValue: 'name',
            validation: { required }
          },
          {
            label: 'Родительская категория',
            placeholder: 'Имя',
            modelValue: 'parentCategoryId',
            type: 'select',
            values: []
          }
        ]
      }
    }
  },
  methods: {
    createCategory (data) {
      this.$api.category.createCategory(data)
        .then(() => {
          this.toast.success('Категория успешно создана')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании категории, повторите позже')
        })
    }
  },
  created () {
    this.$api.category.getParentsCategory()
      .then(data => {
        this.createData.fields[1].values = data.map(item => {
          return Object.assign({}, { text: item.name, value: item.id })
        })
      })
  }
}
</script>
