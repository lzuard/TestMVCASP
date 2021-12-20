<template>
  <showcase-create
    v-bind="createData"
    @onSend="createAddress($event)"
    ref="form"
  />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'AddressCreate',
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
        title: 'Создать адрес',
        fields: [
          {
            label: 'Индекс',
            placeholder: 'Почтовый индекс',
            modelValue: 'index',
            cols: ['col-md-4'],
            validation: { required }
          },
          {
            label: 'Субъект',
            placeholder: 'Субъект',
            modelValue: 'subject',
            cols: ['col-md-4'],
            validation: { required }
          },
          {
            label: 'Населенный пункт',
            placeholder: 'Пункт',
            modelValue: 'location',
            cols: ['col-md-4'],
            validation: { required }
          },
          {
            label: 'Улица',
            placeholder: 'Улица',
            cols: ['col-md-4'],
            modelValue: 'street'
          },
          {
            label: 'Дом',
            placeholder: 'Дом',
            modelValue: 'house',
            cols: ['col-md-2'],
            validation: { required }
          },
          {
            label: 'Строение',
            placeholder: 'Строение',
            cols: ['col-md-2'],
            modelValue: 'building'
          },
          {
            label: 'Корпус',
            placeholder: 'Корпус',
            cols: ['col-md-2'],
            modelValue: 'housing'
          },
          {
            label: 'Комната',
            placeholder: 'Комната',
            modelValue: 'room',
            cols: ['col-md-2']
          }
        ]
      }
    }
  },
  methods: {
    createAddress (data) {
      this.$api.address.createAddress(data)
        .then(() => {
          this.toast.success('Адрес успешно создан')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании адреса, повторите позже')
        })
    }
  }
}
</script>
