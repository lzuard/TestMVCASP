<template>
  <showcase-create ref="form" @onSend="createUtil" v-bind="createData" />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import { required } from '@/utils/validation/i18n-validators'
import { useToast } from 'vue-toastification'

export default {
  name: 'AgentCreate',
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
        title: 'Создать утилизацию',
        fields: [
          {
            label: 'Сотрудник',
            type: 'select',
            values: [],
            modelValue: 'employeeId',
            validation: { required }
          },
          {
            label: 'Номер ТТН',
            type: 'select',
            values: [],
            modelValue: 'ttnId',
            validation: { required }
          },
          {
            label: 'Утилизатор',
            placeholder: 'Утилизатор',
            modelValue: 'utilizerId',
            cols: ['col-md-4'],
            type: 'select',
            validation: { required },
            values: [
              {
                text: 'УтилПро',
                value: 1
              },
              {
                text: 'УтилМакс',
                value: 2
              }
            ]
          },
          {
            label: 'Номер акта утилизации',
            placeholder: '№',
            cols: ['col-md-4'],
            modelValue: 'utilizationAct',
            validation: { required }
          },
          {
            label: 'Дата отгрузки',
            placeholder: 'Дата отгрузки',
            modelValue: 'shipmentDate',
            cols: ['col-md-4'],
            type: 'date',
            validation: { required }
          }
        ],
        enableAddedFields: true,
        subtitle: 'Товары на утилизацию',
        addedFields: [
          {
            label: 'Товар',
            placeholder: 'Артикул',
            type: 'select',
            modelValue: 'productId',
            values: []
          },
          {
            label: 'Количество',
            placeholder: 'Кол-во',
            type: 'number',
            modelValue: 'quantity'
          },
          {
            label: 'Причина утилизации',
            placeholder: 'Причина',
            modelValue: 'reason'
          },
          {
            label: 'Сотрудник, отправивший на утилизацию',
            placeholder: 'Выберите сотрудника',
            type: 'select',
            modelValue: 'employeeId',
            values: []
          }
        ]
      }
    }
  },
  created () {
    this.$api.employee.getEmployee()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'employeeId').values = data.map(item => {
          return Object.assign({}, {
            text: `${item.secondName} ${item.firstName} ${item.thirdName}`,
            value: item.id
          })
        })

        this.createData.addedFields.find(item => item.modelValue === 'employeeId').values = data.map(item => {
          return Object.assign({}, {
            text: `${item.secondName} ${item.firstName} ${item.thirdName}`,
            value: item.id
          })
        })
      })

    this.$api.agent.getAgentByCategory(4)
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'utilizerId').values = data.map(item => {
          return Object.assign({}, {
            text: item.organizationName,
            value: item.id
          })
        })
      })

    this.$api.ttn.getTTNForUsing()
      .then((data) => {
        this.createData.fields.find(item => item.modelValue === 'ttnId').values = data.map(item => {
          return Object.assign({}, {
            text: item.number,
            value: item.id
          })
        })
      })

    this.$api.product.getProductsForUsing()
      .then((data) => {
        this.createData.addedFields.find(item => item.modelValue === 'productId').values = data.map(innerItem => {
          return {
            text: `${innerItem.name} | Артикул: ${innerItem.art}`,
            value: innerItem.id
          }
        })
      })
  },
  methods: {
    createUtil (data, additional) {
      const newData = { ...data, utilProducts: additional }

      this.$api.util.createUtil(newData)
        .then(() => {
          this.toast.success('Утилизация успешно создана')
          this.$refs.form.clearForm()
        })
        .catch(() => {
          this.toast.error('Ошибка при создании утилизации, повторите позже')
        })
    }
  }
}
</script>
